using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;

namespace ClassLibrary.Services.JsonFileServices;

public class JsonFileBlogService : IJsonDataService<Blog>
{
    public string FilePath { get; }

    public JsonFileBlogService(IWebHostEnvironment webHostEnvironment)
    {
        FilePath = Path.Combine(webHostEnvironment.WebRootPath, "data", "blogs.json");
    }

    public JsonFileBlogService(string filePath)
    {
        FilePath = filePath;
    }

    public IEnumerable<Blog> LoadData()
    {
        if (!File.Exists(FilePath))
        {
            return [];
        }

        var jsonData = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<IEnumerable<Blog>>(jsonData) ?? [];
    }

    public void SaveData(IEnumerable<Blog> data)
    {
        var jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true,
        });

        File.WriteAllText(FilePath, jsonData);
    }
}
