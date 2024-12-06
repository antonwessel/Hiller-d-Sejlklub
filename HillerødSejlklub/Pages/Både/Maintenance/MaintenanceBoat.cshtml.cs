using ClassLibrary.Helpers;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både.Maintenance;

public class MaintenanceBoatModel : PageModel
{
    private readonly IBådService _bådService;
    private readonly IMaintenanceService _maintenanceService;

    [BindProperty]
    public List<ClassLibrary.Models.Maintenance> Maintenances { get; set; }


    [BindProperty]
    public Båd Båd { get; set; }

    public MaintenanceBoatModel(IBådService bådService, IMaintenanceService maintenanceService)
    {
        _bådService = bådService;
        _maintenanceService = maintenanceService;
    }

    public IActionResult OnGet(string navn)
    {
        // Kun admins må være her
        if (!AdminState.IsAdminLoggedIn)
        {
            return RedirectToPage("../AlleBåde");
        }

        Båd = _bådService.GetBåd(navn);
        Maintenances = _maintenanceService.GetMaintenances(navn);
        return Page();
    }
}
