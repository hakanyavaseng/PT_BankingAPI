using BankingAPI.Data;
using BankingAPI.Service.Concretes;
using BankingAPI.WebAPI.Filters;
using BankingAPI.WebAPI.Middlewares;
using FluentValidation.AspNetCore;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddControllers(cfg =>
    {
        cfg.Filters.Add<ValidationFilter>();
    })
    .AddFluentValidation(p =>
    {
        p.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDataLayer(builder.Configuration);
builder.Services.AddServiceLayer();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
