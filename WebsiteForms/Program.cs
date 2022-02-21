using Microsoft.AspNetCore.Mvc.Versioning;
using dotenv.net;
using WebsiteForms.Helpers;
using WebsiteForms.Services.UserService;
using WebsiteForms.Repositories.UserRepository;
using WebsiteForms.Repositories.RequestTypesRepository;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(new MediaTypeApiVersionReader("ver"));
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRequestTypeRepository, RequestTypeRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
