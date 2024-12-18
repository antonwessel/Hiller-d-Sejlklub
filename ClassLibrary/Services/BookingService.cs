using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;

namespace ClassLibrary.Services;

public class BookingService : IBookingService
{
    private readonly List<Booking> _bookings = [];
    public IJsonDataService<Booking> JsonDataService { get; }

    public BookingService(IJsonDataService<Booking> jsonDataService)
    {
        JsonDataService = jsonDataService;

        // Henter bookinger fra JSON og laver dem til en liste
        _bookings = JsonDataService.LoadData().ToList();
    }

    public void AddBooking(Boat boatToBook, Member memberToBook, DateTime dateToBok)
    {
        _bookings.Add(new Booking(memberToBook, boatToBook, dateToBok));
        JsonDataService.SaveData(_bookings);
    }

    public void DeleteBooking(Guid bookingId)
    {
        foreach (var booking in _bookings)
        {
            if (booking.Id == bookingId)
            {
                _bookings.Remove(booking);
                JsonDataService.SaveData(_bookings);
                break; // Stopper efter at have fundet og slettet bookingen
            }
        }
    }

    public List<Booking> GetAllBookings(string boatName)
    {
        List<Booking> allBookings = [];

        foreach (var booking in _bookings)
        {
            if (booking.BoatToBook.BoatName == boatName)
            {
                allBookings.Add(booking);
            }
        }
        return allBookings;
    }

    public void UpdateBooking(Booking booking)
    {
        // Gennemgår alle bookinger
        foreach (var bok in _bookings)
        {
            // Finder booking med samme ID
            if (bok.Id == booking.Id)
            {
                // Opdaterer booking med ny information
                bok.DateBooked = booking.DateBooked;
                bok.MemberToBook = booking.MemberToBook;
                bok.BoatToBook = booking.BoatToBook;

                // Gemmer ændringer
                JsonDataService.SaveData(_bookings);
                break; // Stop efter opdatering
            }
        }
    }

    public bool BookingExists(Boat boat, DateTime date)
    {
        // Tjekker om der er en booking for denne båd på denne dato
        return _bookings.Any(b => b.BoatToBook.BoatName == boat.BoatName && b.DateBooked.Date == date.Date);
    }

    public Booking GetBooking(Guid id) => _bookings.FirstOrDefault(booking => booking.Id == id);
}
