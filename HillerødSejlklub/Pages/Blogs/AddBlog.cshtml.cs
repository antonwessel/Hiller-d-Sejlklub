using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Blogs;

public class AddBlogModel : PageModel
{
    private readonly IBlogService _blogService;

    [BindProperty]

    public ClassLibrary.Core.Models.Blog Blog { get; set; }


    public AddBlogModel(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public IActionResult OnGet()
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("AllBlogs");
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _blogService.AddBlog(Blog);
        return RedirectToPage("AllBlogs");
    }
}
