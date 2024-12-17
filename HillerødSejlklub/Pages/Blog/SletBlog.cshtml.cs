using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Blog;

public class SletBlogModel : PageModel
{
    private IBlogService _blogService;

    [BindProperty]

    public ClassLibrary.Core.Models.Blog Blog { get; set; }

    public SletBlogModel(IBlogService blogservice)
    {
        _blogService = blogservice;
    }

    public IActionResult OnGet(string BlogTitle)
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("AlleBlogs");
        }

        Blog = _blogService.GetBlog(BlogTitle);
        return Page();
    }

    public IActionResult OnPost()
    {
        _blogService.DeleteBlog(Blog.BlogTitle);
        return RedirectToPage("AlleBlogs");
    }
}
