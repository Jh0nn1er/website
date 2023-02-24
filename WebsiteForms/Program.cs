using Microsoft.AspNetCore.Mvc.Versioning;
using WebsiteForms.Helpers;
using WebsiteForms.Services.UserService;
using WebsiteForms.Services.PolicyService;
using WebsiteForms.Services.RequestService;
using WebsiteForms.Services.RequestTypeService;
using WebsiteForms.Repositories.Contracts;
using WebsiteForms.Repositories;
using WebsiteForms.Database;
using System.Data.Entity;
using WebsiteForms;
using WebsiteForms.Loging;
using WebsiteForms.Services.EmailService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.AddDbLogger(options => {
    builder.Configuration.GetSection("Logging").GetSection("CustomLogging").GetSection("Options").Bind(options);
    });
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

var services = builder.Services;

services.AddSingleton<IUnitOfWork>(x => new UnitOfWork(new WebsiteFormsContext()));

services.AddTransient<AppSettings, AppSettings>();
services.AddTransient<JwtUtils>();

services.AddScoped<DbContext, WebsiteFormsContext>();
services.AddScoped<IRequestService, RequestService>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<IRequestTypeService, RequestTypeService>();
services.AddScoped<IPolicyService, FileService>();
services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins("https://www.finanzauto.com.co"));

app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
