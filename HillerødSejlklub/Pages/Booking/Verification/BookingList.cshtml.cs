using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Booking.Verification
{
    public class BookingListModel : PageModel
    {
    private IBegivenhedService _begivenhedService;

    [BindProperty]
    public DateTime MinDate { get; set; }

    [BindProperty]
    public DateTime MaxDate { get; set; }

    public List<Event> Begivenheder { get; set; }

    public BegivenhederModel(IBegivenhedService begivenhedService)
    {
        _begivenhedService = begivenhedService;
    }


    public void OnGet()
    {
        Begivenheder = _begivenhedService.GetEvents();
    }

    public IActionResult OnPostFilter()
    {
        Begivenheder = _begivenhedService.FilterByDates(MinDate, MaxDate);
        return Page();
    }

    public IActionResult OnPostReset()
    {
        Begivenheder = _begivenhedService.GetEvents();
        return Page();
    }
}

}
