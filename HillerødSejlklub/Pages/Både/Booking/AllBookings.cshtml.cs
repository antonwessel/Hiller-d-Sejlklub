using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Både.Booking;

public class AllBookingsModel : PageModel
{
    private readonly IBookingService _bookingService;
    private readonly IBoatService _bådService;
    private readonly IMemberService _medlemService;

    [BindProperty] public List<ClassLibrary.Core.Models.Booking> Bookings { get; set; }
    [BindProperty] public string CurrentBoatName { get; set; }
    [BindProperty] public Boat BoatToBook { get; set; }
    [BindProperty] public ClassLibrary.Core.Models.Member MemberToBook { get; set; }
    [BindProperty] public Guid MemberToBookId { get; set; }
    [BindProperty] public List<ClassLibrary.Core.Models.Member> AllMembers { get; set; }
    [BindProperty] public DateTime DateToBook { get; set; }

    public AllBookingsModel(IBookingService bookingService, IBoatService bådService, IMemberService medlemService)
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
        MemberToBook = _medlemService.GetMember(MemberToBookId);
        BoatToBook = _bådService.GetBoat(bådNavn);

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
        AllMembers = _medlemService.GetMembers();
    }
}
