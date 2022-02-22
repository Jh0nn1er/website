using Microsoft.AspNetCore.Mvc.Versioning;
using dotenv.net;
using WebsiteForms.Helpers;
using WebsiteForms.Services.UserService;
using WebsiteForms.Services.PolicyService;
using WebsiteForms.Services.RequestService;
using WebsiteForms.Services.RequestTypeService;
using WebsiteForms.Repositories.Contracts;
using WebsiteForms.Repositories;
using WebsiteForms.Database;
using System.Data.Entity;

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


builder.Services.AddSingleton<IUnitOfWork>(x => new UnitOfWork(new WebsiteFormsContext()));

builder.Services.AddScoped<DbContext, WebsiteFormsContext>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRequestTypeService, RequestTypeService>();
builder.Services.AddScoped<IPolicyService, FileService>();

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
