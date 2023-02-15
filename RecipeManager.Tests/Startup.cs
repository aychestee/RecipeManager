using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeManager.Data;
using System.Reflection;

namespace RecipeManager.Tests
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddApplicationPart(Assembly.Load("RecipeManager")).AddControllersAsServices();

            services.AddControllersWithViews();

            services.AddDbContext<RecipeDatabaseContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Trusted_Connection=True;MultipleActiveResultSets=true;Initial Catalog=recipemanagerdemodb"));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Recipes}/{action=Index}/{id?}");
            });
        }
    }
}