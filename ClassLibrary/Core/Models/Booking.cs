namespace ClassLibrary.Core.Models;

public class Booking
{
    public Guid Id { get; set; }
    public DateTime DateBooked { get; set; }
    public Member MemberToBook { get; set; }
    public Boat BoatToBook { get; set; }

    public Booking(Member member, Boat boat, DateTime date)
    {
        Id = Guid.NewGuid();
        MemberToBook = member;
        BoatToBook = boat;
        DateBooked = date;
    }
    public Booking()
    {
        Id = Guid.NewGuid();
    }
}
