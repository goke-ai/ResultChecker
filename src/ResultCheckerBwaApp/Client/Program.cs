using ResultCheckerBwaApp.Client.Services;
using ResultCheckerBwaApp.Client.Services.AspnetIdentity.Contracts;
using ResultCheckerBwaApp.Client.Services.AspnetIdentity.Implementations;
using ResultCheckerBwaApp.Client.States;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Goke.Net.Services;
using MatBlazor;

namespace ResultCheckerBwaApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            var identity = builder.Configuration["Identity"];

            builder.RootComponents.Add<App>("#app");

            switch (identity)
            {
                case "AspnetIdentity":
                    AddAspnetIdentity(builder); break;
                case "IdentityServer":
                    AddIdentityServer(builder); break;
                default:
                    break;
            };

            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            builder.Services.AddScoped<IApiService, ApiService>();

            builder.Services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.TopRight;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 95;
                config.VisibleStateDuration = 3000;
            });

            await builder.Build().RunAsync();
        }

        private static void AddAspnetIdentity(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<IdentityAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<IdentityAuthenticationStateProvider>());
            builder.Services.AddScoped<IAuthorizeApi, AuthorizeApi>();

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSingleton<IIdentitySetting, AspnetIdentitySetting>();
        }

        private static void AddIdentityServer(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddHttpClient("ResultCheckerBwaApp.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                            .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ResultCheckerBwaApp.ServerAPI"));

            // builder.Services.AddApiAuthorization();
            builder.Services.AddApiAuthorization(
                option =>
                {
                    option.UserOptions.RoleClaim = "role";
                    option.UserOptions.NameClaim = "name";
                });

            builder.Services.AddSingleton<IIdentitySetting, IdentityServerSetting>();
        }
    }
}
