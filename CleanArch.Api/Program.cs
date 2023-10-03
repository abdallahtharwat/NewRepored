using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Ioc;
using FluentAssertions.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionStringNew = builder.Configuration.GetConnectionString("myconnectionNew");
builder.Services.AddDbContext<UniversityDBContext>(options =>
    options.UseSqlServer(connectionStringNew));

builder.Services.AddMediatR(typeof(DependencyContainer));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle




RegisterServices(builder.Services);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Unversity Api", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

//app.UseSwagger();
//app.UseSwaggerUI(c =>
//  {
//      c.SwaggerEndpoint("/swagger/v1/swagger.json", "Unversity Api v1");

//});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    app.UseSwaggerUI((c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Unversity Api v1");
       
    }));
}

app.UseAuthorization();

app.MapControllers();

app.Run();



static void RegisterServices(IServiceCollection services)
{
    DependencyContainer.RegisterServices(services);
}