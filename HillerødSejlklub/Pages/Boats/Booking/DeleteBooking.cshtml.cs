using ClassLibrary.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Boats.Booking;

public class DeleteBookingModel : PageModel
{
    private readonly IBookingService _bookingService;

    public DeleteBookingModel(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [BindProperty]
    public ClassLibrary.Core.Models.Booking Booking { get; set; }

    [BindProperty]
    public Guid BookingId { get; set; }

    public void OnGet(Guid id)
    {
        Booking = _bookingService.GetBooking(id);
        BookingId = id;
    }

    public IActionResult OnPost(string boatName)
    {
        _bookingService.DeleteBooking(BookingId);
        return RedirectToPage("AllBookings", new { boatName });
    }
}
