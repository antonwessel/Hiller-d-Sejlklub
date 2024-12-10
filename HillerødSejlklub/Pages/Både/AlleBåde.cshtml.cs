using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både;

public class AlleBådeModel : PageModel
{
    private IBådService _bådService;
    public List<Båd> Både { get; set; }

    public AlleBådeModel(IBådService bådService)
    {
        _bådService = bådService;
    }

    public void OnGet()
    {
        Både = _bådService.GetBåde();
    }
}
