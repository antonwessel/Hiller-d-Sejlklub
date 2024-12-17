using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både;

public class SletBådModel : PageModel
{
    private IBoatService _bådService;

    [BindProperty]
    public Boat Båd { get; set; }

    public SletBådModel(IBoatService bådService)
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

        Båd = _bådService.GetBoat(navn);
        return Page();
    }

    public IActionResult OnPost()
    {
        _bådService.DeleteBoat(Båd.BoatName);
        return RedirectToPage("AlleBåde");
    }
}
