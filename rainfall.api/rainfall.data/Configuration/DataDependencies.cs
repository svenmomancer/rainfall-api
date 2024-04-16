using Microsoft.Extensions.DependencyInjection;
using rainfall.data.RepositoryQuery;

namespace rainfall.data.Configuration
{
    public static class DataDependencies
    {
        public static void AddDataDependencies(this IServiceCollection service)
        {
            service.AddScoped<IRainfallRepositoryQuery, RainfallRepositoryQuery>();
        }
    }
}
