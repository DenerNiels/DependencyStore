using DependencyStore;
using DependencyStore.Extensions;
using DependencyStore.Models;
using DependencyStore.Repository;
using DependencyStore.Repository.Contracts;
using DependencyStore.Services;
using DependencyStore.Services.Contracts;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<Configuration>();
var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSqlConnection(connStr);
builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();