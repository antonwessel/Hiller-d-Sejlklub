using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Blog;

public class RedigerBlogModel : PageModel
{

    private IBlogService _blogService;

    [BindProperty]

    public ClassLibrary.Core.Models.Blog Blog { get; set; }

    public RedigerBlogModel(IBlogService blogService)
    {
        _blogService = blogService;
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
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _blogService.UpdateBlog(Blog);
        return RedirectToPage("AlleBlogs");
    }
}
