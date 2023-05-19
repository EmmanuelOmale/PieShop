

// This configuration looks at our appSettings.JSON file and loads the settings from that file at startup.
// It makes sure that kestrel is included and setsup IIS integration.
using BeathanyPieShop.Models;
using BethanyPieShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IPieRepository, PieRepository>();

// The following middleware makes sure our application knows about MVC
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BethanysPieShopDbContext>(options => {
    options.UseSqlServer(builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"]);
});
        

var app = builder.Build();
// This   configuration checks for static files incoming request and checks the wwwroot folder and check for that file amd returns it.
app.UseStaticFiles();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Displays the development exception page 
}

//To manage incoming request properly we register the following application

//app.MapDefaultControllerRoute(); // "{controller=Home}/{action=Index}/{id?}"

app.MapDefaultControllerRoute(
    /*name = "defualt",
    pattern = "{controller=Home}/{action=Index}/{id?}"*/);
DbInitializer.Seed(app);
app.Run();


// Program class starts up application 
// ASP.NET Core comes with built-in web server (Kestrel)
// Dependency injection is used by default 
// Handling requests is done through middleware