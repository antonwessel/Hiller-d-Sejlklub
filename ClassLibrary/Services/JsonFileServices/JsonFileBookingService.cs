using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;

namespace ClassLibrary.Services.JsonFileServices;

public class JsonFileBookingService : IJsonDataService<Booking>
{
    public string FilePath { get; }

    public JsonFileBookingService(IWebHostEnvironment webHostEnvironment)
    {
        FilePath = Path.Combine(webHostEnvironment.WebRootPath, "data", "bookings.json");
    }

    public IEnumerable<Booking> LoadData()
    {
        if (!File.Exists(FilePath))
        {
            return [];
        }

        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<IEnumerable<Booking>>(json) ?? [];
    }

    public void SaveData(IEnumerable<Booking> data)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true,
        });
        File.WriteAllText(FilePath, json);
    }
}
