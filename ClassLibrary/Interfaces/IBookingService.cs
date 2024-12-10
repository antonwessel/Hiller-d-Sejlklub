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
        Booking DeleteBooking(string navn);
    }
}
