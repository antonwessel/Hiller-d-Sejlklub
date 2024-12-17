using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;

namespace ClassLibrary.Services.JsonFileServices;

public class JsonFileMemberService : IJsonDataService<Member>
{
    public string FilePath { get; }

    public JsonFileMemberService(IWebHostEnvironment webHostEnvironment)
    {
        FilePath = Path.Combine(webHostEnvironment.WebRootPath, "data", "members.json");
    }

    public IEnumerable<Member> LoadData()
    {
        if (!File.Exists(FilePath))
        {
            return [];
        }

        var jsonData = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<IEnumerable<Member>>(jsonData) ?? [];
    }

    public void SaveData(IEnumerable<Member> data)
    {
        var jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true,
        });
        File.WriteAllText(FilePath, jsonData);
    }
}
