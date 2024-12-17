using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Boats.Maintenance;

public class DeleteMaintenanceModel : PageModel
{
    private IMaintenanceService _maintenanceService;
    private IBoatService _boatService;

    [BindProperty]
    public Boat Boat { get; set; }

    [BindProperty]
    public ClassLibrary.Core.Models.Maintenance Maintenance { get; set; }

    public DeleteMaintenanceModel(IMaintenanceService maintenanceService, IBoatService boatService)
    {
        _maintenanceService = maintenanceService;
        _boatService = boatService;
    }

    public IActionResult OnGet(string Name, Guid maintenanceId)
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("../AlleBåde");
        }

        Boat = _boatService.GetBoat(Name);
        Maintenance = _maintenanceService.GetMaintenance(Name, maintenanceId);
        return Page();
    }

    public IActionResult OnPost(string Name, Guid maintenanceId)
    {
        Boat = _boatService.GetBoat(Name);
        Maintenance = _maintenanceService.GetMaintenance(Name, maintenanceId);
        _maintenanceService.DeleteMaintenance(Name, Maintenance);
        return RedirectToPage("MaintenanceBoat", new { Name });
    }
}
