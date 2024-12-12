using ClassLibrary.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både.Booking;

public class AllBookingsModel : PageModel
{
    private IBookingService _bookingService;

    [BindProperty]
    public List<ClassLibrary.Core.Models.Booking> Bookings { get; set; }

    [BindProperty]
    public string CurrentBoatName { get; set; }

    public AllBookingsModel(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }


    public IActionResult OnGet(string bådNavn)
    {
        CurrentBoatName = bådNavn;
        Bookings = _bookingService.GetAllBookings(bådNavn);
        return Page();
    }
}
