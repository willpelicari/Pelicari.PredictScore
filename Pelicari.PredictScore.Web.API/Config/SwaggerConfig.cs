using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Pelicari.PredictScore.Web.API.Config
{
    public static class SwaggerConfig
    {
        const string VERSION = "v1";
        const string ENDPOINT = "/swagger/v1/swagger.json";
        const string TITLE = "Predict Score v1";

        public static void RunServices(IServiceCollection services) => services.AddSwaggerGen(c => {
            c.EnableAnnotations();
            c.SwaggerDoc(VERSION, new OpenApiInfo() { Title = "Predict Score", Version = VERSION });
        });

        public static void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint(ENDPOINT, TITLE);
            });
        }
    }
}
