using DataAccessLayer.Models;
using DataAccessLayer.Repository.Classes;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using StudentBL;
using StudentBL.Classes;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Add Context to Middlleware
//Change Context to DAL Layer
builder.Services.AddDbContext<SoftoneStudentSystemContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("StuConStr")));
builder.Services.AddScoped<IStudentService,StudentService>();


//builder.Services.AddDbContext<SoftoneStudentSystemContext>(option =>
//option.UseSqlServer(builder.Configuration.GetConnectionString("StuConStr")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
