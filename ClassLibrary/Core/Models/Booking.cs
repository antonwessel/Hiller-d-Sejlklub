using System.Reflection.Metadata.Ecma335;

namespace ClassLibrary.Core.Models;

public class Booking
{

    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime DateBooked { get; set; }
    public Medlem MedlemToBook { get; set; }
    public Båd BoatToBook { get; set; }
   

    public List<Booking> Bookings { get; set; }
    public List<Medlem> Participants { get; set; } = [];


    public Booking(Medlem medlem, Båd boat, List<Booking> booking)
    {

        Id = Guid.NewGuid();
        MedlemToBook = medlem;
        BoatToBook = boat;
        DateBooked = DateTime.Now;
        Bookings = new List<Booking>();

    }
}
