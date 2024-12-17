using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både;

public class AlleBådeModel : PageModel
{
    private IBoatService _bådService;
    public List<Boat> Både { get; set; }

    public AlleBådeModel(IBoatService bådService)
    {
        _bådService = bådService;
    }

    public void OnGet()
    {
        Både = _bådService.GetBoats();
    }
}
