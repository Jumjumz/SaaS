using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using SaaSDashboard.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddFastEndpoints()
    .AddSwaggerGen();

builder.Services.AddDbContext<MariaDBContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DB");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app
    .UseFastEndpoints()
    .UseSwagger();

app.Run();
