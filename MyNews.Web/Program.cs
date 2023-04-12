using Microsoft.EntityFrameworkCore;
using MyNews.BLL.Interfaces;
using MyNews.BLL.Services;
using MyNews.DAL.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyNewsDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyNewsConnnectionString") ?? throw new InvalidOperationException("Connection string 'MvcMovieContext' not found.")));

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IArticlesService, ArticlesService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();