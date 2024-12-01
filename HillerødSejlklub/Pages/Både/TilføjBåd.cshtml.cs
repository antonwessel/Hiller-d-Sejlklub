using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både;

public class TilføjBådModel : PageModel
{
    private IBådService _bådService;

    [BindProperty]
    public Båd Båd { get; set; }

    public TilføjBådModel(IBådService bådService)
    {
        _bådService = bådService;
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
        _bådService.AddBåd(Båd);
        return RedirectToPage("AlleBåde");
    }
}
