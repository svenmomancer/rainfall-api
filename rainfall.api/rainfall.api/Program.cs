using AutoWrapper;
using MediatR;
using Microsoft.OpenApi.Models;
using rainfall.domain.Constants;
using rainfall.service.Configuration;
using rainfall.data.Configuration;
using rainfall.service.Handler;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<FloodMonitoringSettings>(builder.Configuration.GetSection("FloodMonitoringSettings"));

builder.Services.AddControllers().AddNewtonsoftJson(o =>
{
    o.SerializerSettings.DateFormatString = "MMM/dd/yyyy";
    o.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Rainfall Api", 
        Version = "v1.0", 
        Description = "An API which provides rainfall reading data",
        Contact = new OpenApiContact()
        {
            Name = "Sorted",
            Url = new Uri("https://www.sorted.com")
        }
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddServiceDependencies();
builder.Services.AddDataDependencies();
builder.Services.AddMediatR(typeof(QueryHandler));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rainfall Api");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions
{
    ShowApiVersion = true,
    ShowStatusCode = true,
    ApiVersion = "1.0",
    IsApiOnly = true
});

app.Run();
