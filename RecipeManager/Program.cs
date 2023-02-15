using Microsoft.EntityFrameworkCore;
using RecipeManager.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<RecipeDatabaseContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("recipemanagerdatabase"))
);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
} 

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Recipes}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "home",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
