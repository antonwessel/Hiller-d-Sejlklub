using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Blogs;

public class EditBlogModel : PageModel
{
    private readonly IBlogService _blogService;

    [BindProperty]

    public ClassLibrary.Core.Models.Blog Blog { get; set; }

    public EditBlogModel(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public IActionResult OnGet(string blogTitle)
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("AllBlogs");
        }

        Blog = _blogService.GetBlog(blogTitle);
        return Page();
    }
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _blogService.UpdateBlog(Blog);
        return RedirectToPage("AllBlogs");
    }
}
