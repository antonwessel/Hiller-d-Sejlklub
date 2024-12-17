using ClassLibrary.Core.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Blogs;

public class AllBlogsModel : PageModel
{
    private readonly IBlogService _blogService;

    public List<ClassLibrary.Core.Models.Blog> Blogs { get; set; }

    public AllBlogsModel(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public void OnGet()
    {
        Blogs = _blogService.GetBlogs();
    }
}
