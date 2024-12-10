using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Hosting;

namespace ClassLibrary.Services.JsonFileServices;

public class JsonFileBlogService : IJsonDataService<Blog>
{
    public string FilePath { get; }

    public JsonFileBlogService(IWebHostEnvironment webHostEnvironment)
    {
        FilePath = Path.Combine(webHostEnvironment.WebRootPath, "data", "blogs.json");
    }

    public IEnumerable<Blog> LoadData()
    {
        throw new NotImplementedException();
    }

    public void SaveData(IEnumerable<Blog> data)
    {
        throw new NotImplementedException();
    }
}
