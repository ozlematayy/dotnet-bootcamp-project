using Autofac;
using Autofac.Extensions.DependencyInjection;
using DotnetBootcampProject.API.Middlewares;
using DotnetBootcampProject.API.Modules;
using DotnetBootcampProject.Core.Repositories;
using DotnetBootcampProject.Core.Services;
using DotnetBootcampProject.Core.UnitOfWorks;
using DotnetBootcampProject.Repository;
using DotnetBootcampProject.Repository.Repositories;
using DotnetBootcampProject.Repository.UnitOfWorks;
using DotnetBootcampProject.Service.Mapping;
using DotnetBootcampProject.Service.Services;
using DotnetBootcampProject.Service.Validations;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers().AddFluentValidation(x => { x.RegisterValidatorsFromAssemblyContaining<PublisherDtoValidator>(); });

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoModuleService()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCustomException();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
