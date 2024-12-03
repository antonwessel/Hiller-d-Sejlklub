using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både.Maintenance;

public class AddMaintenanceModel : PageModel
{
    private readonly IMaintenanceService _maintenanceService;
    private readonly IBådService _bådService;

    [BindNever] // Lad være med at data validere dette
    public Båd Båd { get; private set; }

    [BindProperty]
    public ClassLibrary.Models.Maintenance Maintenance { get; set; }

    public AddMaintenanceModel(IMaintenanceService maintenanceService, IBådService bådService)
    {
        _maintenanceService = maintenanceService;
        _bådService = bådService;
    }

    public IActionResult OnGet(string bådNavn)
    {
        Båd = _bådService.GetBåd(bådNavn);
        return Page();
    }

    public IActionResult OnPost(string bådNavn)
    {
        if (!ModelState.IsValid)
        {
            Båd = _bådService.GetBåd(bådNavn); // For at undgå null reference exception 
            return Page();
        }

        _maintenanceService.AddMaintenance(bådNavn, Maintenance);
        return RedirectToPage("MaintenanceBoat", new { navn = bådNavn }); // Så vi router tilbage til korrekte båd
    }
}
