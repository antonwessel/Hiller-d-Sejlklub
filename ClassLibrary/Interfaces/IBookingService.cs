using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    interface IBookingService
    {
        void AddBooking(Båd båd, Medlem medlem);
        void UpdateBooking(Booking booking);

        // Kunne man bruge Id i stedet til at finde en booking?
        Booking DeleteBooking(string navn);
    }
}
