using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både;

public class TilføjBoatModel : PageModel
{
    private IBoatService _bådService;

    [BindProperty]
    public Boat Båd { get; set; }

    public TilføjBoatModel(IBoatService bådService)
    {
        _bådService = bådService;
    }

    public IActionResult OnGet()
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("AlleBåde");
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _bådService.AddBoat(Båd);
        return RedirectToPage("AlleBåde");
    }
}
