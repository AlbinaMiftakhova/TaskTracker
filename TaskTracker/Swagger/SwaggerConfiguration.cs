using Microsoft.Extensions.DependencyInjection;

namespace TaskTracker.Swagger
{
    /// <summary>
    /// Extentions for Swagger configuration
    /// </summary>
    public static class SwaggerConfiguration
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerDocument(c =>
            {
                c.Title = "Tasks";
                c.DocumentName = DocumentPartsConst.Tasks;
                c.ApiGroupNames = new[] { DocumentPartsConst.Tasks };
                c.GenerateXmlObjects = true;
            });
            services.AddSwaggerDocument(c =>
            {
                c.Title = "Projects";
                c.DocumentName = DocumentPartsConst.Projects;
                c.ApiGroupNames = new[] { DocumentPartsConst.Projects };
                c.GenerateXmlObjects = true;
            });
        }
    }
}
