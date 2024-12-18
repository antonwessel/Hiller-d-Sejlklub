using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IBookingService
{
    void AddBooking(Boat boatToBook, Member memberToBook, DateTime bookDate);

    /// <summary>
    /// Opdaterer en booking med ny information.
    /// </summary>
    /// <param name="updatedBooking">Den opdaterede booking.</param>
    void UpdateBooking(Booking updatedBooking);

    void DeleteBooking(Guid bookingId);
    List<Booking> GetAllBookings(string boatName);
    IJsonDataService<Booking> JsonDataService { get; }
    bool BookingExists(Boat boatToCheck, DateTime dateToCheck);
    Booking GetBooking(Guid bookingId);
}
