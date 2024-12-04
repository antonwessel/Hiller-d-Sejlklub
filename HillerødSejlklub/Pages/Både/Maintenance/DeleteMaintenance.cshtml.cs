using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både.Maintenance;

public class DeleteMaintenanceModel : PageModel
{
    private IMaintenanceService _maintenanceService;
    private IBådService _bådService;

    [BindProperty]
    public Båd Båd { get; set; }

    [BindProperty]
    public ClassLibrary.Models.Maintenance Maintenance { get; set; }

    public DeleteMaintenanceModel(IMaintenanceService maintenanceService, IBådService bådService)
    {
        _maintenanceService = maintenanceService;
        _bådService = bådService;
    }


    public IActionResult OnGet(string bådNavn, Guid maintenanceId)
    {
        Båd = _bådService.GetBåd(bådNavn);
        Maintenance = _maintenanceService.GetMaintenance(bådNavn, maintenanceId);
        return Page();
    }

    public IActionResult OnPost(string bådNavn, Guid maintenanceId)
    {
        Båd = _bådService.GetBåd(bådNavn);
        Maintenance = _maintenanceService.GetMaintenance(bådNavn, maintenanceId);
        _maintenanceService.DeleteMaintenance(bådNavn, Maintenance);
        return RedirectToPage("MaintenanceBoat", new { navn = bådNavn });
    }
}
