using FluentValidation;
using PersonInformationGrpcService.Application.Mappings;
using PersonInformationGrpcService.Application.Validators;
using PersonInformationGrpcService.Domain.Repositories;
using PersonInformationGrpcService.Infrastructure.Persistence;
using PersonInformationGrpcService.Infrastructure.Repositories;
using PersonInformationGrpcService.Presentation.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;
using PersonInformationGrpcService.Presentation.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddMediatR(m => m.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddValidatorsFromAssemblyContaining<CreatePersonValidator>();

builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Host.UseSerilog((context, config) =>
{
    config.WriteTo.Console()
          .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day);
});

var app = builder.Build();

app.UseMiddleware<DatabaseExceptionMiddleware>();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseMiddleware<RpcExceptionMiddleware>();


// Configure the HTTP request pipeline.
app.MapGrpcService<PersonService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
