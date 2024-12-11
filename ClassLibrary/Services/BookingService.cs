using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services
{

    public class BookingService : IBookingService

    {
        private readonly List<Båd> _både;
        private Guid id;

        public BookingService()
        {
            _både = MockData.MockBåd.GetBoatsAsList();
        }


        public void AddBooking(Båd boat, Medlem medlem)
        {
            _både.Add(boat);
          
        }

     


        public Booking DeleteBooking(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Båd> GetAvailableBoats(List<Båd> allBoats, DateTime date)
        {
            var bookedBoats = _både.Where(b => b.DateBooked.Date == date.Date).Select(b => b.BoatToBook).ToList();
            var availableBoats = allBoats.Where(boat => !bookedBoats.Contains(boat)).ToList(); 
            return availableBoats;
        }

        public void UpdateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

       

        public void AddParticipantToBooking(Medlem participant, Guid bookID)
        {
            foreach (var book in _både)
            {
                if (book.Id == bookID)
                {
                    _både.Add(book);
                    break;
                }
            }
        }

        public List<Båd> GetBookings() => _både;


        public Båd GetBookings(Båd boat, Medlem medlem, DateTime date)
        {
            foreach (var @book in _både)
            {
                if (@book.Id == id)
                {

                    return @book;
                }

            }
            return null;
        }




        public List<Medlem> GetParticipants(Guid eventId)
        {
            foreach (var @event in _både)
            {
                if (eventId == @event.Id)
                {
                    return @event.Participants ?? []; // Tjek om Participants er null
                }
            }
            return [];
        }

        List<Båd> IBookingService.GetBookings(Båd boat, Medlem medlem, DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<Båd> GetBookings(Guid bookId)
        {
            throw new NotImplementedException();
        }

        Booking IBookingService.GetBookings()
        {
            throw new NotImplementedException();
        }
    }
}
