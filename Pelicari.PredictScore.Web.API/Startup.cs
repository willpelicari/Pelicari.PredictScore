using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pelicari.PredictScore.Core.Services;
using Pelicari.PredictScore.Core.Services.Interfaces;
using Pelicari.PredictScore.Data.Models;
using Pelicari.PredictScore.Data.Models.Context;
using Pelicari.PredictScore.Data.Repositories;
using Pelicari.PredictScore.Data.Repositories.Interfaces;
using Pelicari.PredictScore.Web.API.Config;
using Pelicari.PredictScore.Web.API.Mapper;

namespace Pelicari.PredictScore.Web.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            SwaggerConfig.RunServices(services);
            AutoMapping.Setup(services);
            services.AddDbContext<PredictScoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IService<User>, UserService>();
            services.AddScoped<IRepository<Team>, TeamRepository>();
            services.AddScoped<IService<Team>, TeamService>();
            services.AddScoped<IRepository<Sport>, Repository<Sport>>();
            services.AddScoped<IService<Sport>, Service<Sport>>();
            services.AddScoped<IRepository<Score>, Repository<Score>>();
            services.AddScoped<IService<Score>, Service<Score>>();
            services.AddScoped<IRepository<Schedule>, Repository<Schedule>>();
            services.AddScoped<IService<Schedule>, Service<Schedule>>();
            services.AddScoped<IRepository<Round>, Repository<Round>>();
            services.AddScoped<IService<Round>, Service<Round>>();
            services.AddScoped<IRepository<Prediction>, Repository<Prediction>>();
            services.AddScoped<IService<Prediction>, Service<Prediction>>();
            services.AddScoped<IRepository<Group>, Repository<Group>>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IRepository<Game>, Repository<Game>>();
            services.AddScoped<IService<Game>, Service<Game>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            SwaggerConfig.Configure(app);
        }
    }
}
