using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Blog;

public class TilføjBlogModel : PageModel
{
    private IBlogService _blogService;

    [BindProperty]

    public ClassLibrary.Models.Blog Blog { get; set; }


    public TilføjBlogModel(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _blogService.AddBlog(Blog);
        return RedirectToPage("AlleBlogs");
    }

}
