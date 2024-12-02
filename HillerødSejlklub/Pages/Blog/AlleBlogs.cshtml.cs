using ClassLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Blog;

public class AlleBlogsModel : PageModel
{
    private IBlogService _blogService;

    public List<ClassLibrary.Models.Blog> Blogs { get; set; }

    public AlleBlogsModel(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public void OnGet()
    {
        Blogs = _blogService.GetBlogs();
    }
}
