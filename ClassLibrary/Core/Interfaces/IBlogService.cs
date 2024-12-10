using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IBlogService
{
    List<Blog> GetBlogs();
    void AddBlog(Blog blog);
    void UpdateBlog(Blog blog);
    Blog GetBlog(string titel);
    Blog DeleteBlog(string? titel);
}
