using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;

namespace ClassLibrary.Services;

public class BlogService : IBlogService
{
    private List<Blog> _blogListe;
    public IJsonDataService<Blog> JsonDataService { get; }

    public BlogService(IJsonDataService<Blog> jsonDataService)
    {
        JsonDataService = jsonDataService;
        _blogListe = JsonDataService.LoadData().ToList();
    }

    public void AddBlog(Blog blog)
    {
        _blogListe.Add(blog);
        JsonDataService.SaveData(_blogListe);
    }

    public Blog DeleteBlog(string? navn)
    {
        foreach (var blog in _blogListe)
        {
            if (blog.BlogTitle == navn)
            {
                _blogListe.Remove(blog);
                JsonDataService.SaveData(_blogListe);
                return blog;
            }
        }
        return null;
    }

    public Blog GetBlog(string navn)
    {
        foreach (var blog in _blogListe)
        {
            if (blog.BlogTitle == navn)
            {
                return blog;
            }
        }
        return null;
    }

    public List<Blog> GetBlogs() => _blogListe;

    public void UpdateBlog(Blog blog)
    {
        foreach (var bd in _blogListe)
        {
            if (bd.BlogTitle == blog.BlogTitle)
            {
                bd.BlogAuthor = blog.BlogAuthor;
                bd.BlogContent = blog.BlogContent;
                JsonDataService.SaveData(_blogListe);
                break;
            }
        }
    }
}