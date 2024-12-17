using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Boats.Maintenance;

public class AddMaintenanceModel : PageModel
{
    private readonly IMaintenanceService _maintenanceService;
    private readonly IBoatService _boatService;

    [BindNever] // Lad være med at data validere dette
    public Boat Boat { get; private set; }

    [BindProperty]
    public ClassLibrary.Core.Models.Maintenance Maintenance { get; set; }

    public AddMaintenanceModel(IMaintenanceService maintenanceService, IBoatService boatService)
    {
        _maintenanceService = maintenanceService;
        _boatService = boatService;
    }

    public IActionResult OnGet(string Name)
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("../AlleBåde");
        }

        Boat = _boatService.GetBoat(Name);
        return Page();
    }

    public IActionResult OnPost(string Name)
    {
        if (!ModelState.IsValid)
        {
            Boat = _boatService.GetBoat(Name); // For at undgå null reference exception 
            return Page();
        }

        _maintenanceService.AddMaintenance(Name, Maintenance);
        return RedirectToPage("MaintenanceBoat", new { Name = Name }); // Så vi router tilbage til korrekte båd
    }
}
