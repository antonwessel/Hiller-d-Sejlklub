using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Boats;

public class EditBoatModel : PageModel
{
    private readonly IBoatService _boatService;

    [BindProperty]
    public Boat Boat { get; set; }

    public EditBoatModel(IBoatService boatService)
    {
        _boatService = boatService;
    }

    public IActionResult OnGet(string boatName)
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("AlleBåde");
        }

        Boat = _boatService.GetBoat(boatName);
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _boatService.UpdateBoat(Boat);
        return RedirectToPage("AlleBåde");
    }
}
