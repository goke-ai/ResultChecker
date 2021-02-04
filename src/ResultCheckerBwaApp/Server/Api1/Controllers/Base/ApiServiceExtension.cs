
namespace Ark.ResultCheckers.Api1.Services
{
    using Microsoft.Extensions.DependencyInjection;
    
    public static class ApiServiceExtension
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
        }
    }
}
