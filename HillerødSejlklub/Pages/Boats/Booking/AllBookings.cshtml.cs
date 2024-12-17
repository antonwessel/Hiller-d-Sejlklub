using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Boats.Booking;

public class AllBookingsModel : PageModel
{
    private readonly IBookingService _bookingService;
    private readonly IBoatService _boatService;
    private readonly IMemberService _memberService;

    [BindProperty] public List<ClassLibrary.Core.Models.Booking> Bookings { get; set; }
    [BindProperty] public string CurrentBoatName { get; set; }
    [BindProperty] public Boat BoatToBook { get; set; }
    [BindProperty] public Member MemberToBook { get; set; }
    [BindProperty] public Guid MemberToBookId { get; set; }
    [BindProperty] public List<Member> AllMembers { get; set; }
    [BindProperty] public DateTime DateToBook { get; set; }

    public AllBookingsModel(IBookingService bookingService, IBoatService boatService, IMemberService medlemService)
    {
        _bookingService = bookingService;
        _boatService = boatService;
        _memberService = medlemService;
    }

    public IActionResult OnGet(string boatName)
    {
        LoadData(boatName);
        return Page();
    }

    public IActionResult OnPost(string boatName)
    {
        MemberToBook = _memberService.GetMember(MemberToBookId);
        BoatToBook = _boatService.GetBoat(boatName);

        // Check om der allerede er en booking med samme Date.
        if (_bookingService.BookingExists(BoatToBook, DateToBook))
        {
            ModelState.AddModelError(string.Empty, "Der eksisterer allerede en booking for denne Date.");
            LoadData(boatName);
            return Page();
        }


        _bookingService.AddBooking(BoatToBook, MemberToBook, DateToBook);
        LoadData(boatName);
        return Page();
    }

    private void LoadData(string boatName)
    {
        CurrentBoatName = boatName;
        Bookings = _bookingService.GetAllBookings(boatName);
        AllMembers = _memberService.GetMembers();
    }
}
