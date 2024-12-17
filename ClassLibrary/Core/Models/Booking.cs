using System.Reflection.Metadata.Ecma335;

namespace ClassLibrary.Core.Models;

public class Booking
{
    public Guid Id { get; set; }
    public DateTime DateBooked { get; set; }
    public Member MedlemToBook { get; set; }
    public Boat BoatToBook { get; set; }

    public Booking(Member medlem, Boat boat, DateTime date)
    {
        Id = Guid.NewGuid();
        MedlemToBook = medlem;
        BoatToBook = boat;
        DateBooked = date;
    }
    public Booking()
    {
        Id = Guid.NewGuid();
    }
}
