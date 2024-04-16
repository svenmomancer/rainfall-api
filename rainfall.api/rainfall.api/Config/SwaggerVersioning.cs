using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace rainfall.api.Config
{
    public class SwaggerVersioning
    {
        public class RemoveVersionFromParameter : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                if (operation.Parameters.Count > 0)
                {
                    var versionParam = operation.Parameters.Single(x => x.Name == "version");
                    operation.Parameters.Remove(versionParam);
                }
            }
        }

        public class ReplaceVersionWithExacValueInPath : IDocumentFilter
        {
            public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
            {
                var paths = swaggerDoc.Paths;
                swaggerDoc.Paths = new OpenApiPaths();

                foreach (var path in paths)
                {
                    var key = path.Key.Replace("v{version}", swaggerDoc.Info.Version);
                    var value = path.Value;
                    swaggerDoc.Paths.Add(key, value);
                }
            }
        }
    }
}
