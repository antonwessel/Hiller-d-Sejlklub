using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både;

public class AlleBådeModel : PageModel
{
    private IBoatService _boatService;
    public List<Boat> Boats { get; set; }

    public AlleBådeModel(IBoatService boatService)
    {
        _boatService = boatService;
    }

    public void OnGet()
    {
        Boats = _boatService.GetBoats();
    }
}
