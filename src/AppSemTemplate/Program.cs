using AppSemTemplate.Data;
using AppSemTemplate.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//builder.Services.AddRouting(options =>
//    options.ConstraintMap["slugify"] = typeof(RouteSlugifyParameterTrasnformer));


builder.Services.AddDbContext<AppDbContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller:slugify=Home}/{action:slugify=Index}/{id?}"
//);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.Run();
