using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using ClassLibrary.MockData;

namespace ClassLibrary.Services;

public class BlogService : IBlogService
{
    private List<Blog> _blogListe;

    public BlogService()
    {
        _blogListe = MockBlog.GetBlogsAsList();
    }

    public void AddBlog(Blog blog)
    {
        _blogListe.Add(blog);
    }

    public Blog DeleteBlog(string? navn)
    {
        foreach (var blog in _blogListe)
        {
            if (blog.BlogTitel == navn)
            {
                _blogListe.Remove(blog);
                return blog;
            }
        }
        return null;
    }

    public Blog GetBlog(string navn)
    {
        foreach (var blog in _blogListe)
        {
            if (blog.BlogTitel == navn)
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
            if (bd.BlogTitel == blog.BlogTitel)
            {
                bd.BlogForfatter = blog.BlogForfatter;
                bd.BlogIndhold = blog.BlogIndhold;
                break;
            }
        }
    }
}
