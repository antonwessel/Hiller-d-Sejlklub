using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;

namespace ClassLibrary.Services.JsonFileServices;

public class JsonFileEventService : IJsonDataService<Event>
{
    public string FilePath { get; }

    public JsonFileEventService(IWebHostEnvironment webHostEnvironment)
    {
        FilePath = Path.Combine(webHostEnvironment.WebRootPath, "data", "events.json");
    }

    public JsonFileEventService(string filePath)
    {
        FilePath = filePath;
    }

    public IEnumerable<Event> LoadData()
    {
        if (!File.Exists(FilePath))
        {
            return [];
        }

        var jsonData = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<IEnumerable<Event>>(jsonData) ?? [];
    }

    public void SaveData(IEnumerable<Event> data)
    {
        var jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true,
        });
        File.WriteAllText(FilePath, jsonData);
    }
}