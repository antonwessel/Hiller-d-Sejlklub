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
        _bookings = JsonDataService.LoadData().ToList();
    }

    public void AddBooking(Boat boat, Member medlem, DateTime date)
    {
        _bookings.Add(new Booking(medlem, boat, date));
        JsonDataService.SaveData(_bookings);
    }

    public void DeleteBooking(Guid id)
    {
        foreach (var booking in _bookings)
        {
            if (booking.Id == id)
            {
                _bookings.Remove(booking);
                JsonDataService.SaveData(_bookings);
                break;
            }
        }
    }

    public List<Booking> GetAllBookings(string bådNavn)
    {
        List<Booking> allBookings = [];
        foreach (var booking in _bookings)
        {
            if (booking.BoatToBook.BoatName == bådNavn)
            {
                allBookings.Add(booking);
            }
        }
        return allBookings;
    }

    public void UpdateBooking(Booking booking)
    {
        foreach (var bok in _bookings)
        {
            if (bok.Id == booking.Id)
            {
                bok.DateBooked = booking.DateBooked;
                bok.MemberToBook = booking.MemberToBook;
                bok.BoatToBook = booking.BoatToBook;
                JsonDataService.SaveData(_bookings);
                break;
            }
        }
    }

    public bool BookingExists(Boat boat, DateTime date)
    {
        return _bookings.Any(b => b.BoatToBook.BoatName == boat.BoatName && b.DateBooked.Date == date.Date);
    }

    public Booking GetBooking(Guid id) => _bookings.FirstOrDefault(booking => booking.Id == id);
}
