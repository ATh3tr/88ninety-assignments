using Microsoft.EntityFrameworkCore;
using UniversityData.Context;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using UniversityApi.Modules;
using AutoWrapper;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new RepositoryModule());
    containerBuilder.RegisterModule(new ServiceModule());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

builder.Services.AddDbContext<UniversityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseApiResponseAndExceptionWrapper();

app.MapControllers();

app.Run();
