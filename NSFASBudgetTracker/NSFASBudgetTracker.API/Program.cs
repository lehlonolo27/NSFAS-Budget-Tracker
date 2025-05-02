using NSFASBudgetTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using NSFASBudgetTracker.Core.Interfaces;
using NSFASBudgetTracker.Infrastructure.Repositories;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IBudgetRepository, BudgetRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.Run();
