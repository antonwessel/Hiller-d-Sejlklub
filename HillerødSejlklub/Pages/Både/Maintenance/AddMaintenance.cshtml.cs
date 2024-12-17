using ClassLibrary.Core.Helpers;
using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både.Maintenance;

public class AddMaintenanceModel : PageModel
{
    private readonly IMaintenanceService _maintenanceService;
    private readonly IBoatService _bådService;

    [BindNever] // Lad være med at data validere dette
    public Boat Båd { get; private set; }

    [BindProperty]
    public ClassLibrary.Core.Models.Maintenance Maintenance { get; set; }

    public AddMaintenanceModel(IMaintenanceService maintenanceService, IBoatService bådService)
    {
        _maintenanceService = maintenanceService;
        _bådService = bådService;
    }

    public IActionResult OnGet(string bådNavn)
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("../AlleBåde");
        }

        Båd = _bådService.GetBoat(bådNavn);
        return Page();
    }

    public IActionResult OnPost(string bådNavn)
    {
        if (!ModelState.IsValid)
        {
            Båd = _bådService.GetBoat(bådNavn); // For at undgå null reference exception 
            return Page();
        }

        _maintenanceService.AddMaintenance(bådNavn, Maintenance);
        return RedirectToPage("MaintenanceBoat", new { navn = bådNavn }); // Så vi router tilbage til korrekte båd
    }
}
