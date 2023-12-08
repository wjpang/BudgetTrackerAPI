using Microsoft.EntityFrameworkCore;
using BudgetTracker.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BudgetTrackerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BudgetTrackerContext") ?? throw new InvalidOperationException("Connection string 'BudgetContext' not found.")));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAntiforgery();
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
