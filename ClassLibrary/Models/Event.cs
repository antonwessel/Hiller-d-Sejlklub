using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models;

public class Event
{
    [Required(ErrorMessage = "Navn er påkrævet.")]
    [StringLength(100, ErrorMessage = "Navnet må ikke være længere end 100 tegn.")]
    public string Navn { get; set; }

    [Required(ErrorMessage = "Dato er påkrævet.")]
    [DataType(DataType.Date, ErrorMessage = "Datoen skal være i et korrekt format.")]
    public DateTime Dato { get; set; }

    [Required(ErrorMessage = "Lokation er påkrævet.")]
    [StringLength(200, ErrorMessage = "Lokationen må ikke være længere end 200 tegn.")]
    public string Lokation { get; set; }

    public List<Medlem> Participants { get; set; } = [];

    public Guid Id { get; set; } = Guid.NewGuid();

    public Event(string navn, DateTime dato, string lokation)
    {
        Navn = navn;
        Dato = dato;
        Lokation = lokation;
    }

    public Event()
    {
    }
}
