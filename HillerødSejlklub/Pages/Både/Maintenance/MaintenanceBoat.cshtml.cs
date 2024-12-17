using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både.Maintenance;

public class MaintenanceBoatModel : PageModel
{
    private readonly IBoatService _bådService;
    private readonly IMaintenanceService _maintenanceService;

    [BindProperty]
    public List<ClassLibrary.Core.Models.Maintenance> Maintenances { get; set; }

    [BindProperty]
    public float MaintenancesDone { get; set; }

    [BindProperty]
    public Boat Båd { get; set; }

    public MaintenanceBoatModel(IBoatService bådService, IMaintenanceService maintenanceService)
    {
        _bådService = bådService;
        _maintenanceService = maintenanceService;
    }

    public IActionResult OnGet(string navn)
    {
        Båd = _bådService.GetBoat(navn);
        Maintenances = _maintenanceService.GetMaintenances(navn);
        MaintenancesDone = _maintenanceService.GetMaintenancesDone(navn);
        return Page();
    }
}
