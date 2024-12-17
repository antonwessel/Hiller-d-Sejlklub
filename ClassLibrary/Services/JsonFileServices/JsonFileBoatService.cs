using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;

namespace ClassLibrary.Services.JsonFileServices;

public class JsonFileBoatService : IJsonDataService<Boat>
{
    public string FilePath { get; }

    public JsonFileBoatService(IWebHostEnvironment webHostEnvironment)
    {
        FilePath = Path.Combine(webHostEnvironment.WebRootPath, "data", "boats.json");
    }

    public IEnumerable<Boat> LoadData()
    {
        if (!File.Exists(FilePath))
        {
            return [];
        }

        var jsonData = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<IEnumerable<Boat>>(jsonData) ?? [];
    }

    public void SaveData(IEnumerable<Boat> data)
    {
        var jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true,
        });
        File.WriteAllText(FilePath, jsonData);
    }
}
