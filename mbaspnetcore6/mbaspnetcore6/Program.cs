// WebApplication: The Web ENvironment that is common for
// Razor Views, MVC, and APIs
// Build and Initialize the HTTP Pipeline for
// 1. Registeing all Dependencies as Service
// 2. Middlewares
var builder = WebApplication.CreateBuilder(args);

// The builder is a WebApplicationBuilder class
// THis is used to Provide the 'Dependency Container'
// This provides the ApplicationBuilder

// Add services to the container.
// The 'Services' is of the type 'IServiceCollection' which is DI Container
// to register all Services

builder.Services.AddControllersWithViews();


// Application Builder for Registering Middlewares for
// HTTP Pipelie
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Redirect HTTP Request to HTTPS while production
app.UseHttpsRedirection();
// Read all Static files for Download/Upload Operations 
app.UseStaticFiles();
// Contains a Route Table
app.UseRouting();
// For Role Based Security
app.UseAuthorization();
// Pass the Request to MVC Controllers
// That matches with the ControllerName in Route Table
// Default is HomeController class and its method is Index 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

