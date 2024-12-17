using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Boats;

public class DeleteBoatModel : PageModel
{
    private readonly IBoatService _boatService;

    [BindProperty]
    public Boat Boat { get; set; }

    public DeleteBoatModel(IBoatService boatService)
    {
        _boatService = boatService;
    }

    public IActionResult OnGet(string Name)
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("AlleBåde");
        }

        Boat = _boatService.GetBoat(Name);
        return Page();
    }

    public IActionResult OnPost()
    {
        _boatService.DeleteBoat(Boat.BoatName);
        return RedirectToPage("AlleBåde");
    }
}
