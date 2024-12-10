using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IBookingService
{
    void AddBooking(Båd boat, Medlem medlem);
    void UpdateBooking(Booking booking);
    Booking DeleteBooking(Guid id);
}
