using Microsoft.EntityFrameworkCore;
using BudgetTracker.Data;
using BudgetTracker.Services;
using BudgetTracker.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITransactionEntryService, TransactionEntryService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();

var connectionString = builder.Configuration.GetConnectionString("BudgetTrackerContext");
if (connectionString is null)
{
    throw new InvalidOperationException("Connection string 'BudgetTrackerContext' not found.");
}

// Sql Server
// builder.Services.AddDbContext<BudgetTrackerContext>(options =>
//     options.UseSqlServer(connectionString));

// MySql
// builder.Services.AddDbContext<BudgetTrackerContext>(options =>
//     options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// SQLite
builder.Services.AddSqlite<BudgetTrackerContext>(connectionString);

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
