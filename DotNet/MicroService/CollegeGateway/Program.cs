using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", policy =>
    {
        policy.WithOrigins("https://localhost:7254")  // Blazor port
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddOcelot();


var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();
app.UseCors("AllowBlazorClient");
await app.UseOcelot();

app.UseAuthorization();

app.MapControllers();

app.Run();
