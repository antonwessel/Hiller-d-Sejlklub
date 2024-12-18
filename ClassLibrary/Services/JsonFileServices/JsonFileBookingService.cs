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

    public JsonFileBookingService(string filePath)
    {
        FilePath = filePath;
    }

    public IEnumerable<Booking> LoadData()
    {
        if (!File.Exists(FilePath))
        {
            return [];
        }

        var jsonData = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<IEnumerable<Booking>>(jsonData) ?? [];
    }

    public void SaveData(IEnumerable<Booking> data)
    {
        var jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true,
        });
        File.WriteAllText(FilePath, jsonData);
    }
}
