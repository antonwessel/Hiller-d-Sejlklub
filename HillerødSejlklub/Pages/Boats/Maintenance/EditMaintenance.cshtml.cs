using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Boats.Maintenance;

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

    public IActionResult OnGet(string Name, Guid id)
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("../AlleBåde");
        }

        Boat = _boatService.GetBoat(Name);
        Maintenance = _maintenanceService.GetMaintenance(Name, id);
        return Page();
    }

    public IActionResult OnPost(string Name)
    {
        Boat = _boatService.GetBoat(Name);

        if (!ModelState.IsValid)
        {
            Boat = _boatService.GetBoat(Name);
            return Page();
        }

        _maintenanceService.UpdateMaintenance(Name, Maintenance);
        return RedirectToPage("MaintenanceBoat", new { Name });
    }
}
