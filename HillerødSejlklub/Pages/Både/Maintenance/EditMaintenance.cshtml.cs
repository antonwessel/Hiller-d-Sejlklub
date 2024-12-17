using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både.Maintenance;

public class EditMaintenanceModel : PageModel
{
    private IMaintenanceService _maintenanceService;
    private IBoatService _bådService;

    [BindNever]
    public Boat Båd { get; set; }

    [BindProperty]
    public ClassLibrary.Core.Models.Maintenance Maintenance { get; set; }

    public EditMaintenanceModel(IMaintenanceService maintenanceService, IBoatService bådService)
    {
        _maintenanceService = maintenanceService;
        _bådService = bådService;
    }

    public IActionResult OnGet(string bådNavn, Guid id)
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("../AlleBåde");
        }

        Båd = _bådService.GetBoat(bådNavn);
        Maintenance = _maintenanceService.GetMaintenance(bådNavn, id);
        return Page();
    }

    public IActionResult OnPost(string bådNavn, Guid id)
    {
        Båd = _bådService.GetBoat(bådNavn);

        if (!ModelState.IsValid)
        {
            Båd = _bådService.GetBoat(bådNavn);
            return Page();
        }

        _maintenanceService.UpdateMaintenance(bådNavn, Maintenance);
        return RedirectToPage("MaintenanceBoat", new { navn = bådNavn });

    }
}
