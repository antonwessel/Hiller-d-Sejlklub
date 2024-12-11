using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services
{
    public class BookingService : IBookingService

    {
        private readonly List<Booking> _bookings = new();

        public void AddBooking(Båd boat, Medlem medlem, DateTime date)
        {
            _bookings.Add(new Booking(date, medlem, boat)); //
        }


        public Booking DeleteBooking(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Båd> GetAvailableBoats(List<Båd> allBoats, DateTime date)
        {
            var bookedBoats = _bookings.Where(b => b.DateBooked.Date == date.Date).Select(b => b.BoatToBook).ToList();
            var availableBoats = allBoats.Where(boat => !bookedBoats.Contains(boat)).ToList(); 
            return availableBoats;
        }

        public void UpdateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
