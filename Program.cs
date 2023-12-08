using Microsoft.EntityFrameworkCore;
using BudgetTracker.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BudgetTrackerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BudgetTrackerContext") ?? throw new InvalidOperationException("Connection string 'BudgetContext' not found.")));

// To use SQLite in development and SQL Server in production.
// if (builder.Environment.IsDevelopment())
// {
//     builder.Services.AddDbContext<BudgetTrackerContext>(options =>
//         options.UseSqlite(builder.Configuration.GetConnectionString("BudgetTrackerContext")));
// }
// else
// {
//     builder.Services.AddDbContext<BudgetTrackerContext>(options =>
//         options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionBudgetTrackerContext")));
// }

// Add services to the container.

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

app.MapControllers();

app.Run();
