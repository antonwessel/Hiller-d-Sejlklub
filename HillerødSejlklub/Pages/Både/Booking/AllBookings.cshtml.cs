using ClassLibrary.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både.Booking;

public class AllBookingsModel : PageModel
{
    private IBookingService _bookingService;

    [BindProperty]
    public List<ClassLibrary.Core.Models.Booking> Bookings { get; set; }

    public IActionResult OnGet(string bådNavn)
    {
        try
        {
            Bookings = _bookingService.GetAllBookings(bådNavn);
        }
        catch (NullReferenceException)
        {
            Bookings = [];
        }

        return Page();
    }
}
