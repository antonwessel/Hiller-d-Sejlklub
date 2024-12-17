using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary.Core.Models;
using ClassLibrary.Core.Interfaces;

namespace HillerødSejlklub.Pages.Events;

public class AllEventsModel : PageModel
{
    private readonly IEventService _eventService;

    [BindProperty]
    public DateTime MinDate { get; set; }

    [BindProperty]
    public DateTime MaxDate { get; set; }

    public List<Event> Begivenheder { get; set; }

    public AllEventsModel(IEventService eventService)
    {
        _eventService = eventService;
    }

    public void OnGet()
    {
        MinDate = DateTime.Today;
        MaxDate = DateTime.Today.AddYears(1);
        Begivenheder = _eventService.GetEvents();
    }

    public IActionResult OnPostFilter()
    {
        Begivenheder = _eventService.FilterByDates(MinDate, MaxDate);
        return Page();
    }

    public IActionResult OnPostReset()
    {
        MinDate = DateTime.Today;
        MaxDate = DateTime.Today.AddYears(1);
        Begivenheder = _eventService.GetEvents();
        return Page();
    }
}
