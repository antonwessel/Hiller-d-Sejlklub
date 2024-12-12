using System.Reflection.Metadata.Ecma335;

namespace ClassLibrary.Core.Models;

public class Booking
{
    public Guid Id { get; set; }
    public DateTime DateBooked { get; set; }
    public Medlem MedlemToBook { get; set; }
    public Båd BoatToBook { get; set; }

    public Booking(Medlem medlem, Båd boat)
    {
        Id = Guid.NewGuid();
        MedlemToBook = medlem;
        BoatToBook = boat;
        DateBooked = DateTime.Now;
    }
    public Booking()
    {
        Id = Guid.NewGuid();
    }
}
