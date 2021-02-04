using ResultCheckerBwaApp.Server.Models;
using ResultCheckerBwaApp.Shared;
using ResultCheckerBwaApp.Shared.AspnetIdentity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ark.ResultCheckers.Data;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Encodings.Web;

namespace ResultCheckerBwaApp.Server.AspnetIdentity.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AuthorizeController> _logger;
        private readonly IEmailSender _emailSender;
        AppDbContext _context;
        RoleManager<IdentityRole> _roleManager;

        public AuthorizeController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<AuthorizeController> logger,
            IEmailSender emailSender,
            AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginParameters parameters)
        {
            var user = await _userManager.FindByNameAsync(parameters.UserName);
            if (user == null)
            {
                //
                user = await CreateUserFromPin(parameters);
                if (user == null)
                {
                    return BadRequest("User does not exist");
                }
            }
            var singInResult = await _signInManager.CheckPasswordSignInAsync(user, parameters.Password, false);
            if (!singInResult.Succeeded) return BadRequest("Invalid password");

            await _signInManager.SignInAsync(user, parameters.RememberMe);

            return Ok();
        }

        async Task<ApplicationUser> CreateUserFromPin(LoginParameters parameters)
        {
            ApplicationUser user = null;
            //
            var card = _context.Cards.FirstOrDefault(a => a.Pin == parameters.Password);
            if (card?.Pin == parameters.Password)
            {
                if (card?.Owner == parameters.UserName)
                {
                    // used just login
                }
                else if ( string.IsNullOrWhiteSpace(card.Owner))
                {
                    // new pin
                    user = new ApplicationUser { UserName = parameters.UserName, Email = $"{parameters.UserName}@ark.com" };
                    var result = await _userManager.CreateAsync(user, parameters.Password);

                    if (!result.Succeeded) 
                        throw new Exception(result.Errors.FirstOrDefault()?.Description);

                    _logger.LogInformation("User created a new account with password.");

                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code/*, returnUrl = returnUrl*/ },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(parameters.UserName, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    result = await _userManager.ConfirmEmailAsync(user, token);

                    // used card
                    card.Owner = parameters.UserName;
                    card.EditTracker(User.Identity.Name);
                    int rows = await _context.SaveChangesAsync();

                    // add role
                    IdentityResult IR = null;
                    var role = card.Role;
                    if (!await _roleManager.RoleExistsAsync(role))
                    {
                        IR = await _roleManager.CreateAsync(new IdentityRole(role));
                    }

                    IR = await _userManager.AddToRoleAsync(user, role);
                }
                else
                {

                }
            }
            return user;
        }

        (bool Valid, string Owner) ValidPin(string pin)
        {
            var card = _context.Cards.FirstOrDefault(a => a.Pin == pin);
            return (card?.Pin == pin, card?.Owner);
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterParameters parameters, string returnUrl)
        {
            var user = new ApplicationUser { UserName = parameters.UserName, Email = $"{parameters.UserName}@ark.com" };
            var result = await _userManager.CreateAsync(user, parameters.Password);
            if (!result.Succeeded) return BadRequest(result.Errors.FirstOrDefault()?.Description);

            _logger.LogInformation("User created a new account with password.");

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                protocol: Request.Scheme);

            await _emailSender.SendEmailAsync(parameters.UserName, "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            result = await _userManager.ConfirmEmailAsync(user, token);

            return await Login(new LoginParameters
            {
                UserName = parameters.UserName,
                Password = parameters.Password
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpGet]
        public UserInfo UserInfo()
        {
            //var user = await _userManager.GetUserAsync(HttpContext.User);
            return BuildUserInfo();
        }


        private UserInfo BuildUserInfo()
        {
            return new UserInfo
            {
                IsAuthenticated = User.Identity.IsAuthenticated,
                UserName = User.Identity.Name,
                ExposedClaims = User.Claims
                    //Optionally: filter the claims you want to expose to the client
                    //.Where(c => c.Type == "test-claim")
                    // .ToDictionary(c => c.Type, c => c.Value)
                    .Select(c => new KeyValuePair<string,string>(c.Type, c.Value)).ToList()
            };
        }
    }
}
