using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både.Maintenance;

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

    public IActionResult OnGet(string boatName, Guid maintenanceId)
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("../AlleBåde");
        }

        Boat = _boatService.GetBoat(boatName);
        Maintenance = _maintenanceService.GetMaintenance(boatName, maintenanceId);
        return Page();
    }

    public IActionResult OnPost(string boatName, Guid maintenanceId)
    {
        Boat = _boatService.GetBoat(boatName);
        Maintenance = _maintenanceService.GetMaintenance(boatName, maintenanceId);
        _maintenanceService.DeleteMaintenance(boatName, Maintenance);
        return RedirectToPage("MaintenanceBoat", new { boatName });
    }
}
