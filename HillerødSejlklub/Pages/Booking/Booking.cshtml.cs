using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerødSejlklub.Pages.Booking
{
   
    
        public class BookingBoatModel : PageModel
        {
            private readonly IBookingService _bookingService;
            private readonly IBådService _bådService;

            [BindProperty]
            public DateTime BookingDate { get; set; }

            public List<Båd> AvailableBoats { get; set; } // Liste over ledige både

            public BookingBoatModel(IBookingService bookingService, IBådService bådService)
            {
                _bookingService = bookingService;
                _bådService = bådService;
                BookingDate = DateTime.Now;


            }

            public void OnGet()
            {
                
                AvailableBoats = new List<Båd>();
            }

            public void OnPost()
            {
                if (BookingDate == default)
                {
                    ModelState.AddModelError("", "Vælg venligst en gyldig dato.");
                    AvailableBoats = new List<Båd>();
                    return;
                }

                // henter alle både
                var allBoats = _bådService.GetBåde();

                // den henter vores ledig både, men ser på datoen
                AvailableBoats = _bookingService.GetAvailableBoats(allBoats, BookingDate);
            }
        }

    
}
