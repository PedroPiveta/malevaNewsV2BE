global using malevaNewsV2.Models;
global using malevaNewsV2.Services;
global using malevaNewsV2.Dtos.Post;
using malevaNewsV2.Data;
using dotenv.net;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load();

builder.Services.AddDbContext<DataContext>(options => 
    options.UseNpgsql($"Host={Environment.GetEnvironmentVariable("DBHOST")};" +
                    $"Port={Environment.GetEnvironmentVariable("DBPORT")};" +
                    $"Database={Environment.GetEnvironmentVariable("DATABASE_NAME")};" +
                    $"Username={Environment.GetEnvironmentVariable("USERNAME")};" +
                    $"Password={Environment.GetEnvironmentVariable("PASSWORD")};" +
                    "TrustServerCertificate=true")
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IPostServices, PostServices>();

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
