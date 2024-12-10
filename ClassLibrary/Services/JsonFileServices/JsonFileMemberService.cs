using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;

namespace ClassLibrary.Services.JsonFileServices;

public class JsonFileMemberService : IJsonDataService<Medlem>
{
    public string FilePath { get; }

    public JsonFileMemberService(IWebHostEnvironment webHostEnvironment)
    {
        FilePath = Path.Combine(webHostEnvironment.WebRootPath, "data", "members.json");
    }

    public IEnumerable<Medlem> LoadData()
    {
        if (!File.Exists(FilePath))
        {
            return [];
        }

        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<IEnumerable<Medlem>>(json) ?? [];
    }

    public void SaveData(IEnumerable<Medlem> data)
    {
        var json = JsonSerializer.Serialize(data);
        File.WriteAllText(FilePath, json);
    }
}
