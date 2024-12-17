using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IBlogService
{
    List<Blog> GetBlogs();
    void AddBlog(Blog blogToAdd);
    void UpdateBlog(Blog updatedBlog);
    Blog GetBlog(string blogTitle);
    Blog DeleteBlog(string? blogTitle);
    IJsonDataService<Blog> JsonDataService { get; }
}
