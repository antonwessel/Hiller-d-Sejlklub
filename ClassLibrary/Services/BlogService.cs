using ClassLibrary.Interfaces;
using ClassLibrary.MockData;
using ClassLibrary.Models;

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

	public Blog DeleteBlog(string? titel)
	{
		throw new NotImplementedException();
	}

	public Blog GetBlog(string titel)
	{
		throw new NotImplementedException();
	}

	public List<Blog> GetBlogs() => MockData.MockBlog.GetBlogsAsList();

	public void UpdateBlog(Blog blog)
	{
		throw new NotImplementedException();
	}
}
