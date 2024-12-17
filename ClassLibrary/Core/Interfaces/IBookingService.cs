using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IBookingService
{
    void AddBooking(Boat boatToBook, Member memberToBook, DateTime bookDate);
    void UpdateBooking(Booking updatedBooking);
    void DeleteBooking(Guid bookingId);
    List<Booking> GetAllBookings(string boatName);
    IJsonDataService<Booking> JsonDataService { get; }
    bool BookingExists(Boat boatToCheck, DateTime dateToCheck);
    Booking GetBooking(Guid bookingId);
}
