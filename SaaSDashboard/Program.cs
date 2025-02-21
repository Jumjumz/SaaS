using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using SaaSDashboard.Data;
using SaaSDashboard.Interfaces;
using SaaSDashboard.Repository.Users;

using FastEndpoints.Swagger;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<MySettings>(builder.Configuration.GetSection("MySettings"));

builder.Services
    .AddFastEndpoints()
    .SwaggerDocument(o =>
{
    // IServiceProvider is available via DocumentOptions.Services property
    var settings = o.Services.GetRequiredService<IOptions<MySettings>>().Value;
    
    o.DocumentSettings = s =>
    {
        s.DocumentName = "v1"; 
        s.Title = settings.AppName;  
        s.Version = settings.Version;  
        s.Description = "This is my API documentation.";
    };
});

builder.Services.AddDbContext<MariaDBContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DB");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
);
builder.Services.AddScoped<IUser, UserRepository>();

var app = builder.Build();

app.UseHttpsRedirection();
app
    .UseFastEndpoints()
    .UseSwaggerGen();

app.Run();

public class MySettings
{
    public string AppName { get; set; } = "SaaSDashboard";
    public string Version { get; set; } = "v1";
}

