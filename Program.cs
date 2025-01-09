
using Microsoft.EntityFrameworkCore;
using SoftOneStudentSystemWebApi.RequestModel;
using StudentBL;
using StudentSystemWebApi;
using StudentSystemWebApi.DataAccessLayer.Models;
using StudentSystemWebApi.StudentBL.Classes;
using StudentSystemWebApi.StudentBL.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Add Context to Middlleware
//Change Context to DAL Layer
builder.Services.AddDbContext<GitstudentContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("StuConStr")));
builder.Services.AddScoped<IStudentService,StudentService>();
builder.Services.AddScoped<ICourseService, CourseService>();
//MyOptions.ConnectionString = builder.Configuration.GetConnectionString("StuConStr");

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
if (app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/error-development");
}
else
{
	app.UseExceptionHandler("/error");
}
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
