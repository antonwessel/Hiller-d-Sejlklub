using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Blog
{
    public class SletBlogModel : PageModel
    {
        private IBlogService _blogService;

        [BindProperty]

        public ClassLibrary.Models.Blog Blog { get; set; }

        public SletBlogModel(IBlogService blogservice)
        {
            _blogService = blogservice;
        }

        public IActionResult OnGet(string BlogTitel)
        {
            Blog = _blogService.GetBlog(BlogTitel);
            return Page();
        }

        public IActionResult OnPost()
        {
            _blogService.DeleteBlog(Blog.BlogTitel);
            return RedirectToPage("AlleBlogs");
        }
    }
}
