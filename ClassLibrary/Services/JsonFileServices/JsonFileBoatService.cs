using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;

namespace ClassLibrary.Services.JsonFileServices;

public class JsonFileBoatService : IJsonDataService<Båd>
{
    public string FilePath { get; }

    public JsonFileBoatService(IWebHostEnvironment webHostEnvironment)
    {
        FilePath = Path.Combine(webHostEnvironment.WebRootPath, "data", "boats.json");
    }

    public IEnumerable<Båd> LoadData()
    {
        if (!File.Exists(FilePath))
        {
            return [];
        }

        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<IEnumerable<Båd>>(json) ?? [];
    }

    public void SaveData(IEnumerable<Båd> data)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true,
        });
        File.WriteAllText(FilePath, json);
    }
}
