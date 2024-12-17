using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både.Maintenance;

public class DeleteMaintenanceModel : PageModel
{
    private IMaintenanceService _maintenanceService;
    private IBoatService _bådService;

    [BindProperty]
    public Boat Båd { get; set; }

    [BindProperty]
    public ClassLibrary.Core.Models.Maintenance Maintenance { get; set; }

    public DeleteMaintenanceModel(IMaintenanceService maintenanceService, IBoatService bådService)
    {
        _maintenanceService = maintenanceService;
        _bådService = bådService;
    }


    public IActionResult OnGet(string bådNavn, Guid maintenanceId)
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("../AlleBåde");
        }

        Båd = _bådService.GetBoat(bådNavn);
        Maintenance = _maintenanceService.GetMaintenance(bådNavn, maintenanceId);
        return Page();
    }

    public IActionResult OnPost(string bådNavn, Guid maintenanceId)
    {
        Båd = _bådService.GetBoat(bådNavn);
        Maintenance = _maintenanceService.GetMaintenance(bådNavn, maintenanceId);
        _maintenanceService.DeleteMaintenance(bådNavn, Maintenance);
        return RedirectToPage("MaintenanceBoat", new { navn = bådNavn });
    }
}
