using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Core.Models;

public class Event
{
    [Required(ErrorMessage = "Name er påkrævet.")]
    [StringLength(100, ErrorMessage = "Nameet må ikke være længere end 100 tegn.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Date er påkrævet.")]
    [DataType(DataType.Date, ErrorMessage = "Dateen skal være i et korrekt format.")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Location er påkrævet.")]
    [StringLength(200, ErrorMessage = "Locationen må ikke være længere end 200 tegn.")]
    public string Location { get; set; }

    public List<Member> Participants { get; set; } = [];

    public Guid Id { get; set; } = Guid.NewGuid();

    public Event(string name, DateTime date, string location)
    {
        Name = name;
        Date = date;
        Location = location;
    }

    public Event()
    {
    }
}
