using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både.Maintenance;

public class EditMaintenanceModel : PageModel
{
    private readonly IMaintenanceService _maintenanceService;
    private readonly IBoatService _boatService;

    [BindNever]
    public Boat Boat { get; set; }

    [BindProperty]
    public ClassLibrary.Core.Models.Maintenance Maintenance { get; set; }

    public EditMaintenanceModel(IMaintenanceService maintenanceService, IBoatService boatService)
    {
        _maintenanceService = maintenanceService;
        _boatService = boatService;
    }

    public IActionResult OnGet(string boatName, Guid id)
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("../AlleBåde");
        }

        Boat = _boatService.GetBoat(boatName);
        Maintenance = _maintenanceService.GetMaintenance(boatName, id);
        return Page();
    }

    public IActionResult OnPost(string boatName)
    {
        Boat = _boatService.GetBoat(boatName);

        if (!ModelState.IsValid)
        {
            Boat = _boatService.GetBoat(boatName);
            return Page();
        }

        _maintenanceService.UpdateMaintenance(boatName, Maintenance);
        return RedirectToPage("MaintenanceBoat", new { boatName });
    }
}
