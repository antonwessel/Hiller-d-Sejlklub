using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using ClassLibrary.Services;
using ClassLibrary.Services.JsonFileServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Dependency injections to our repo classes
builder.Services.AddSingleton<IMedlemService, MedlemService>();
builder.Services.AddSingleton<IBådService, BådService>();
builder.Services.AddSingleton<IBegivenhedService, BegivenhedService>();
builder.Services.AddSingleton<IBlogService, BlogService>();
builder.Services.AddSingleton<IMaintenanceService, MaintenanceService>();

// Dependency injections to our json classes
builder.Services.AddSingleton<IJsonDataService<Medlem>, JsonFileMemberService>();


var app = builder.Build();

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

app.MapRazorPages();

app.Run();
