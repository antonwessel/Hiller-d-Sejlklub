using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IBookingService
{
    void AddBooking(Boat boat, Member member, DateTime date);
    void UpdateBooking(Booking booking);
    void DeleteBooking(Guid id);
    List<Booking> GetAllBookings(string boatName);
    IJsonDataService<Booking> JsonDataService { get; }
    bool BookingExists(Boat boat, DateTime date);
    Booking GetBooking(Guid id);
}
