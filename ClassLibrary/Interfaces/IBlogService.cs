using ClassLibrary.Models;

namespace ClassLibrary.Interfaces;

public interface IBlogService
{
    List<Blog> GetBlogs();
    void AddBlog(Blog blog);
    void UpdateBlog(Blog blog);
    Blog GetBlog(string titel);
    Blog DeleteBlog(string? titel);
}
