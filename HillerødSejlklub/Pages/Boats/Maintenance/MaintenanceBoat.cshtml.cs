using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Boats.Maintenance;

public class MaintenanceBoatModel : PageModel
{
    private readonly IBoatService _boatService;
    private readonly IMaintenanceService _maintenanceService;

    [BindProperty]
    public List<ClassLibrary.Core.Models.Maintenance> Maintenances { get; set; }

    [BindProperty]
    public float MaintenancesDone { get; set; }

    [BindProperty]
    public Boat Boat { get; set; }

    public MaintenanceBoatModel(IBoatService boatService, IMaintenanceService maintenanceService)
    {
        _boatService = boatService;
        _maintenanceService = maintenanceService;
    }

    public IActionResult OnGet(string boatName)
    {
        Boat = _boatService.GetBoat(boatName);
        Maintenances = _maintenanceService.GetMaintenances(boatName);
        MaintenancesDone = _maintenanceService.GetMaintenancesDone(boatName);
        return Page();
    }
}
