using Microsoft.EntityFrameworkCore;
using store.Data;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load("../.env");

Console.WriteLine("USER=" + Env.GetString("DB_USER"));
Console.WriteLine("PASS=" + Env.GetString("DB_PASSWORD"));

var connectionString =
    $"server={Env.GetString("DB_HOST")};" +
    $"database={Env.GetString("DB_NAME")};" +
    $"user={Env.GetString("DB_USER")};" +
    $"password={Env.GetString("DB_PASSWORD")};";

Console.WriteLine(connectionString);

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();