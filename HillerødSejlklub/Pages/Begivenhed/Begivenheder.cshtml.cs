using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary.Core.Models;
using ClassLibrary.Core.Interfaces;

namespace HillerødSejlklub.Pages.Begivenhed;

public class BegivenhederModel : PageModel
{
    private IEventService _begivenhedService;

    [BindProperty]
    public DateTime MinDate { get; set; }

    [BindProperty]
    public DateTime MaxDate { get; set; }

    public List<Event> Begivenheder { get; set; }

    public BegivenhederModel(IEventService begivenhedService)
    {
        _begivenhedService = begivenhedService;
    }


    public void OnGet()
    {
        MinDate = DateTime.Today;
        MaxDate = DateTime.Today.AddYears(1);
        Begivenheder = _begivenhedService.GetEvents();
    }

    public IActionResult OnPostFilter()
    {
        Begivenheder = _begivenhedService.FilterByDates(MinDate, MaxDate);
        return Page();
    }

    public IActionResult OnPostReset()
    {
        MinDate = DateTime.Today;
        MaxDate = DateTime.Today.AddYears(1);
        Begivenheder = _begivenhedService.GetEvents();
        return Page();
    }
}
