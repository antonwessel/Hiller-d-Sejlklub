using ClassLibrary.Helpers;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Blog
{
    public class RedigerBlogModel : PageModel
    {

        private IBlogService _blogService;

        [BindProperty]

        public ClassLibrary.Models.Blog Blog { get; set; }

        public RedigerBlogModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult OnGet(string BlogTitel)
        {
            // Kun admins må være her
            if (!AdminState.IsAdminLoggedIn)
            {
                return RedirectToPage("AlleBlogs");
            }

            Blog = _blogService.GetBlog(BlogTitel);
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
}
