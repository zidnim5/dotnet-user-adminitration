global using dotnet_user_adminitration.Models;
global using dotnet_user_adminitration.Data;
global using dotnet_user_adminitration.Dtos;
using dotnet_user_adminitration.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IImagesService, ImageService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

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
