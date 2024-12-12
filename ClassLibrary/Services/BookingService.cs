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

    public void AddBooking(Båd boat, Medlem medlem)
    {
        _bookings.Add(new Booking(medlem, boat));
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
            if (booking.BoatToBook.Navn == bådNavn)
            {
                allBookings.Add(booking);
            }
        }
        return allBookings;
    }

    public List<Båd> GetAvailableBoats(List<Båd> allBoats, DateTime date)
    {
        var bookedBoats = _bookings.Where(b => b.DateBooked.Date == date.Date).Select(b => b.BoatToBook).ToList();
        var availableBoats = allBoats.Where(boat => !bookedBoats.Contains(boat)).ToList();
        return availableBoats;
    }

    public void UpdateBooking(Booking booking)
    {
        foreach (var bok in _bookings)
        {
            if (bok.Id == booking.Id)
            {
                bok.DateBooked = booking.DateBooked;
                bok.MedlemToBook = booking.MedlemToBook;
                bok.BoatToBook = booking.BoatToBook;
                JsonDataService.SaveData(_bookings);
                break;
            }
        }
    }
}
