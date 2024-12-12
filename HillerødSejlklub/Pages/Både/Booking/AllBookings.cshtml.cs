using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både.Booking;

public class AllBookingsModel : PageModel
{
    private readonly IBookingService _bookingService;
    private readonly IBådService _bådService;
    private readonly IMedlemService _medlemService;

    [BindProperty] public List<ClassLibrary.Core.Models.Booking> Bookings { get; set; }
    [BindProperty] public string CurrentBoatName { get; set; }
    [BindProperty] public Båd BoatToBook { get; set; }
    [BindProperty] public ClassLibrary.Core.Models.Medlem MemberToBook { get; set; }
    [BindProperty] public Guid MemberToBookId { get; set; }
    [BindProperty] public List<ClassLibrary.Core.Models.Medlem> AllMembers { get; set; }
    [BindProperty] public DateTime DateToBook { get; set; }

    public AllBookingsModel(IBookingService bookingService, IBådService bådService, IMedlemService medlemService)
    {
        _bookingService = bookingService;
        _bådService = bådService;
        _medlemService = medlemService;
    }

    public IActionResult OnGet(string bådNavn)
    {
        LoadData(bådNavn);
        return Page();
    }

    public IActionResult OnPost(string bådNavn)
    {
        MemberToBook = _medlemService.GetMedlem(MemberToBookId);
        BoatToBook = _bådService.GetBåd(bådNavn);

        // Check om der allerede er en booking med samme dato.
        if (_bookingService.BookingExists(BoatToBook, DateToBook))
        {
            ModelState.AddModelError(string.Empty, "Der eksisterer allerede en booking for denne dato.");
            LoadData(bådNavn);
            return Page();
        }


        _bookingService.AddBooking(BoatToBook, MemberToBook, DateToBook);
        LoadData(bådNavn);
        return Page();
    }

    private void LoadData(string bådNavn)
    {
        CurrentBoatName = bådNavn;
        Bookings = _bookingService.GetAllBookings(bådNavn);
        AllMembers = _medlemService.GetMedlemmer();
    }
}
