
namespace Ark.Iskools.Api2.Services
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
