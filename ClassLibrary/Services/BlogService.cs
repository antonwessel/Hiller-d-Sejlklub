using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;

namespace ClassLibrary.Services;

public class BlogService : IBlogService
{
    private readonly List<Blog> _blogs;
    public IJsonDataService<Blog> JsonDataService { get; }

    public BlogService(IJsonDataService<Blog> jsonDataService)
    {
        JsonDataService = jsonDataService;
        _blogs = JsonDataService.LoadData().ToList();
    }

    public void AddBlog(Blog blogToAdd)
    {
        _blogs.Add(blogToAdd);
        JsonDataService.SaveData(_blogs);
    }

    public Blog DeleteBlog(string blogTitle)
    {
        var blogToDelete = _blogs.FirstOrDefault(blog => blog.BlogTitle == blogTitle);
        if (blogToDelete != null)
        {
            _blogs.Remove(blogToDelete);
            JsonDataService.SaveData(_blogs);
        }
        return blogToDelete;
    }

    public Blog GetBlog(string blogTitle) => _blogs.FirstOrDefault(blog => blog.BlogTitle == blogTitle);

    public List<Blog> GetBlogs() => _blogs;

    public void UpdateBlog(Blog updatedBlog)
    {
        var existingBlog = _blogs.FirstOrDefault(b => b.BlogTitle == updatedBlog.BlogTitle);
        if (existingBlog != null)
        {
            existingBlog.BlogAuthor = updatedBlog.BlogAuthor;
            existingBlog.BlogContent = updatedBlog.BlogContent;
            JsonDataService.SaveData(_blogs);
            // Gemmer ændringer i JSON
        }
    }
}
