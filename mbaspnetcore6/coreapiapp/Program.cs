using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using coreapiapp.AuthServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SecurityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SecurityConnStr"));
});
///Resolve UserManager and SignInManager
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<SecurityDbContext>();
    

// Add The Logic for Validating the Token
// Infor the Service That the Token Has to be read from the Header
// And the same must be used for Authentication
// Read the Signeture from appsettings.json
byte[] secretSignKey = Convert.FromBase64String( builder.Configuration["JwtSettings:Signeture"]);

builder.Services.AddAuthentication(tk =>
{
    tk.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    tk.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Write a Logic to Validate the Token based on the Signeture 
.AddJwtBearer(data =>
{
    data.RequireHttpsMetadata = false;
    data.SaveToken = true; // Save The token in Server's Process
    data.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretSignKey),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Register the AUthServive

builder.Services.AddScoped<AuthService>();

// Add Dependencies in DI Container
builder.Services.AddScoped<IDataAccess<Department,int>, DepartmentDataAccess>();
builder.Services.AddScoped<IDataAccess<Employee, int>, EmployeeDataAccess>();


builder.Services.AddScoped<IServiceRepository<Department, int>, DepartmentRepository>();
builder.Services.AddScoped<IServiceRepository<Employee, int>, EmployeeRepository>();

// Service methodc for WEb API 
builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Service fir Creating an Open EndPoints using Swagger and put them by creating a TEST UI Page
builder.Services.AddEndpointsApiExplorer();
// Generate the Swagger JSON DOcumentation, that is used for
// USed for Creating aProxy Class that can be used by
// .NET Client App as CSharp class
// Client-Side JavaScript LIbraries or Frameworks
// those are coded using 'TypeScript'
// This is Open API Specifications 3.0 (OAS3.0)
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Middlewares for Accepting HTTP Request for Testing
    // using Swagger User Interface
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


// Register the Custom Middleware
app.UseExceptionHandlerMiddleware();




// Map the Request for API COntroller
app.MapControllers();

app.Run();

