using ClassLibrary.Helpers;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både;

public class SletBådModel : PageModel
{
    private IBådService _bådService;

    [BindProperty]
    public Båd Båd { get; set; }

    public SletBådModel(IBådService bådService)
    {
        _bådService = bådService;
    }

    public IActionResult OnGet(string navn)
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("AlleBåde");
        }

        Båd = _bådService.GetBåd(navn);
        return Page();
    }

    public IActionResult OnPost()
    {
        _bådService.DeleteBåd(Båd.Navn);
        return RedirectToPage("AlleBåde");
    }
}
