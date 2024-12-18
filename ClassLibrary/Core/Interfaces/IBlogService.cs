using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IBlogService
{
    List<Blog> GetBlogs();
    void AddBlog(Blog blogToAdd);

    /// <summary>
    /// Opdaterer en blog med ny information.
    /// </summary>
    /// <param name="updatedBlog">Den opdaterede blog.</param>
    void UpdateBlog(Blog updatedBlog);

    Blog GetBlog(string blogTitle);
    Blog DeleteBlog(string? blogTitle);
    IJsonDataService<Blog> JsonDataService { get; }
}
