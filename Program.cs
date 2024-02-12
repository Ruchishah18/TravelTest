using AutoMapper;
using DataAccess.Extention;
using FluentValidation;
using IntuitiveTest;
using IntuitiveTest.Interfaces;
using IntuitiveTest.Services;
using IntuitiveTest.ValidationOnRequest;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddValidatorsFromAssemblyContaining<CreateCountryRequestValidation>();

var mappingConfig = new MapperConfiguration(c => c.AddProfile(new MappingProfiles()));
builder.Services.AddSingleton(mappingConfig.CreateMapper());

builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IAirportService, AirportService>();
builder.Services.AddScoped<IRouteService, RouteService>();
//Connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddAirportDataBase(connectionString);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler(a => a.Run(async context =>
{
    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
    var exception = exceptionHandlerPathFeature.Error;

    await context.Response.WriteAsJsonAsync(new { error = exception.Message });
}));

app.MapControllers();

app.Run();
