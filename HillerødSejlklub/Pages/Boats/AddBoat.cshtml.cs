using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Boats;

public class AddBoatModel : PageModel
{
    private readonly IBoatService _boatService;

    [BindProperty]
    public Boat Boat { get; set; }

    public AddBoatModel(IBoatService boatService)
    {
        _boatService = boatService;
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
        _boatService.AddBoat(Boat);
        return RedirectToPage("AllBoats");
    }
}
