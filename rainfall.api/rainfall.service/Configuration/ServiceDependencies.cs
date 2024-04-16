using Microsoft.Extensions.DependencyInjection;
using rainfall.service.ServiceQuery;

namespace rainfall.service.Configuration
{
    public static class ServiceDependencies
    {
        public static void AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRainfallServiceQuery, RainfallServiceQuery>();
        }
    }
}
