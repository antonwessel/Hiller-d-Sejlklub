using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Core.Models;

public class Event
{
    [Required(ErrorMessage = "Navn er påkrævet.")]
    [StringLength(100, ErrorMessage = "Navnet må ikke være længere end 100 tegn.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Dato er påkrævet.")]
    [DataType(DataType.Date, ErrorMessage = "Datoen skal være i et korrekt format.")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Lokation er påkrævet.")]
    [StringLength(200, ErrorMessage = "Lokationen må ikke være længere end 200 tegn.")]
    public string Location { get; set; }

    public List<Member> Participants { get; set; } = [];

    public Guid Id { get; set; } = Guid.NewGuid();

    public Event(string name, DateTime dato, string location)
    {
        Name = name;
        Date = dato;
        Location = location;
    }

    public Event()
    {
    }
}
