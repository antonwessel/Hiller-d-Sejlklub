using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både;

public class MaintenanceBoatModel : PageModel
{
    private IBådService _bådService;

    [BindProperty]
    public List<Maintenance> Maintenances { get; set; }

    [BindProperty]
    public Båd Båd { get; set; }

    public MaintenanceBoatModel(IBådService bådService)
    {
        _bådService = bådService;
    }

    public void OnGet(string navn)
    {
        Båd = _bådService.GetBåd(navn);
        Maintenances = _bådService.GetMaintenances(navn);
    }
}
