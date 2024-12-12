using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IBookingService
{
    void AddBooking(Båd boat, Medlem medlem, DateTime date);
    void UpdateBooking(Booking booking);
    void DeleteBooking(Guid id);
    List<Booking> GetAllBookings(string bådNavn);
    IJsonDataService<Booking> JsonDataService { get; }
    bool BookingExists(Båd boat, DateTime date);
    Booking GetBooking(Guid id);


    List<Båd> GetAvailableBoats(List<Båd> allBoats, DateTime date); // Ny metode
}
