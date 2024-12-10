namespace ClassLibrary.Core.Models;

public class Booking
{
    public Guid Id { get; set; }
    public DateTime DateBooked { get; set; }
    public Medlem MedlemToBook { get; set; }
    public Båd BoatToBook { get; set; }

    public Booking(DateTime date, Medlem medlem, Båd boat)
    {
        Id = Guid.NewGuid();
        DateBooked = date;
        MedlemToBook = medlem;
        BoatToBook = boat;
    }
}
