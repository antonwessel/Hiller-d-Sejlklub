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

    public IEnumerable<Event> LoadData()
    {
        if (!File.Exists(FilePath))
        {
            return [];
        }

        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<IEnumerable<Event>>(json) ?? [];
    }

    public void SaveData(IEnumerable<Event> data)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true,
        });
        File.WriteAllText(FilePath, json);
    }
}