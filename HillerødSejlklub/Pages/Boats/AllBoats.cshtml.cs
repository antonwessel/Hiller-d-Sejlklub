using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Boats;

public class AllBoatsModel : PageModel
{
    private readonly IBoatService _boatService;
    public List<Boat> Boats { get; set; }

    public AllBoatsModel(IBoatService boatService)
    {
        _boatService = boatService;
    }

    public void OnGet()
    {
        Boats = _boatService.GetBoats();
    }
}
