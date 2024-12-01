using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både;

public class RedigerBådModel : PageModel
{
    private IBådService _bådService;

    [BindProperty]
    public Båd Båd { get; set; }

    public RedigerBådModel(IBådService bådService)
    {
        _bådService = bådService;
    }

    public IActionResult OnGet(string navn)
    {
        Båd = _bådService.GetBåd(navn);
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _bådService.UpdateBåd(Båd);
        return RedirectToPage("AlleBåde");
    }
}
