using ClassLibrary.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både.Booking;

public class AllBookingsModel : PageModel
{
    private IBookingService _bookingService;

    public AllBookingsModel(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [BindProperty]
    public List<ClassLibrary.Core.Models.Booking> Bookings { get; set; } = [];

    public IActionResult OnGet(string bådNavn)
    {
        Bookings = _bookingService.GetAllBookings(bådNavn);
        return Page();
    }
}
