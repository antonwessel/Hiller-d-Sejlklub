using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IBookingService
{
    void AddBooking(Båd boat, Medlem medlem);
    void UpdateBooking(Booking booking);
    Booking DeleteBooking(Guid id);
    void AddParticipantToBooking(Medlem participant, Guid bookID);
    List<Båd> GetBookings(Båd boat, Medlem medlem, DateTime date);
    List<Båd> GetAvailableBoats(List<Båd> allBoats, DateTime date); // Ny metode
    List<Medlem> GetParticipants(Guid bookId);
    List<Båd> GetBookings(Guid bookId);
    Booking GetBookings();
}
