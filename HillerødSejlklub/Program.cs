using ClassLibrary.Interfaces;
using ClassLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// Dependency injections
builder.Services.AddSingleton<IMedlemService, MedlemService>();
builder.Services.AddSingleton<IBådService, BådService>();
builder.Services.AddSingleton<IBegivenhedService, BegivenhedService>();
builder.Services.AddSingleton<IBlogService, BlogService>();
builder.Services.AddSingleton<IMaintenanceService, MaintenanceService>();


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
