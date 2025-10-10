using Microsoft.EntityFrameworkCore;
using Per.Order.Infrastructure.Persistence.Context;
using Per.Order.Presentation.Modules;
using Per.Order.Application;
using Per.Order.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructureService();

builder.Services.AddDbContext<AplicationDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer API V1");
    });
}

app.UseHttpsRedirection();

ModulesConfiguration.Configure(app);

app.Run();
