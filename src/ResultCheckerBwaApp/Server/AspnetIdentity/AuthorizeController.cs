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

namespace ResultCheckerBwaApp.Server.AspnetIdentity.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        AppDbContext _context;
        RoleManager<IdentityRole> _roleManager;

        public AuthorizeController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _roleManager = roleManager;
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
            var x = ValidPin(parameters.Password);
            if (x.Valid)
            {
                if (x.Owner == parameters.UserName)
                {
                    // used just login
                }
                else if ( string.IsNullOrWhiteSpace(x.Owner))
                {
                    // new pin
                    user = new ApplicationUser();
                    user.UserName = parameters.UserName;
                    var result = await _userManager.CreateAsync(user, parameters.Password);
                    if (!result.Succeeded) 
                        throw new Exception(result.Errors.FirstOrDefault()?.Description);

                    // add role
                    IdentityResult IR = null;
                    var role = "Students";
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
            return (card?.Pin == pin, card?.LastActivityUser);
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterParameters parameters)
        {
            var user = new ApplicationUser();
            user.UserName = parameters.UserName;
            var result = await _userManager.CreateAsync(user, parameters.Password);
            if (!result.Succeeded) return BadRequest(result.Errors.FirstOrDefault()?.Description);

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
