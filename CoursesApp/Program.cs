using CourseEnv.Core.Factories;
using CourseEnv.Core.Interfaces;
using CourseEnv.Core.Services;
using CourseEnv.Infrastructure.Data;
using CourseEnv.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CourseAppDatabase");

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddDbContext<CourseContext>(options =>
   options.UseSqlServer(connectionString));
builder.Services.AddTransient<ICourseRepository, CourseRepository>();
builder.Services.AddTransient<ICourseFactory, CourseFactory>();
builder.Services.AddTransient<ICourseInstanceRepository, CourseInstanceRepository>();
builder.Services.AddTransient<ICourseInstanceService, CourseInstanceService>();
builder.Services.AddTransient<ICourseService, CourseService>();

builder.Services.AddControllers();

builder.Services.AddCors(options => { options.AddPolicy("frontend", policy => { policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials(); }); });

var app = builder.Build();

app.UseCors("frontend");

app.UseDeveloperExceptionPage();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapRazorPages();

app.MapControllers();

app.Run();
