using Microsoft.EntityFrameworkCore;
using Mysql_App.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddDbContext<StudentDbContext>(optionsAction =>
//    optionsAction.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
//    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
//    )
//);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
