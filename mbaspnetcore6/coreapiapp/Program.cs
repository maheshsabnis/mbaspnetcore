var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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


app.UseAuthorization();


// Register the Custom Middleware
app.UseExceptionHandlerMiddleware();




// Map the Request for API COntroller
app.MapControllers();

app.Run();

