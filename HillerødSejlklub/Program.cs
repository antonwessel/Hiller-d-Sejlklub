using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using ClassLibrary.Services;
using ClassLibrary.Services.JsonFileServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register JSON file services for data persistence
builder.Services.AddSingleton<IJsonDataService<Member>, JsonFileMemberService>();
builder.Services.AddSingleton<IJsonDataService<Blog>, JsonFileBlogService>();
builder.Services.AddSingleton<IJsonDataService<Event>, JsonFileEventService>();
builder.Services.AddSingleton<IJsonDataService<Boat>, JsonFileBoatService>();
builder.Services.AddSingleton<IJsonDataService<Booking>, JsonFileBookingService>();

// Register application services
builder.Services.AddSingleton<IMemberService, MemberService>();
builder.Services.AddSingleton<IEventService, EventService>();
builder.Services.AddSingleton<IBlogService, BlogService>();
builder.Services.AddSingleton<IMaintenanceService, MaintenanceService>();
builder.Services.AddSingleton<IBookingService, BookingService>();

// Register BoatService with IBookingService as a dependency
builder.Services.AddSingleton<IBoatService>(provider =>
{
    var maintenanceService = provider.GetRequiredService<IMaintenanceService>();
    var jsonDataService = provider.GetRequiredService<IJsonDataService<Boat>>();
    var bookingService = provider.GetRequiredService<IBookingService>();
    return new BoatService(maintenanceService, jsonDataService, bookingService);
});

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
