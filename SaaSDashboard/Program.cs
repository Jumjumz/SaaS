using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using SaaSDashboard.Data;
using SaaSDashboard.Interfaces;
using SaaSDashboard.Repository.Users;
using FastEndpoints.Swagger;
using Microsoft.Extensions.Options;
using SaaSDashboard.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// interfaces and repository
builder.Services.AddScoped<IUser, UserRepository>();
// fast endpoint config
builder.Services
    .AddFastEndpoints()
    .Configure<MySettings>(builder.Configuration.GetSection("MySettings"))
    .SwaggerDocument(o =>
{
    var settings = o.Services.GetRequiredService<IOptions<MySettings>>().Value;
    
    o.DocumentSettings = s =>
    {
        s.DocumentName = "v1"; 
        s.Title = settings.AppName;  
        s.Version = settings.Version;  
        s.Description = "This is a SaaS API documentation.";
    };
});

builder.Services.AddDbContext<MariaDBContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DB");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
);

var app = builder.Build();

app.UseHttpsRedirection();
app
    .UseFastEndpoints()
    .UseSwaggerGen();

app.Run();

