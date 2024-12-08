using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models;

public class Medlem
{
    [Key] // Indicates this is the primary key if used with Entity Framework
    public Guid Id { get; set; } = Guid.NewGuid(); // Automatically assigns a new GUID

    [Required(ErrorMessage = "Navn er påkrævet.")]
    [StringLength(50, ErrorMessage = "Navn må ikke være længere end 50 tegn.")]
    public string Navn { get; set; }

    [Required(ErrorMessage = "Telefonnummer er påkrævet.")]
    [RegularExpression(@"^\d{8}$", ErrorMessage = "Telefonnummer skal være et gyldigt 8-cifret tal.")]
    public string TelefonNummer { get; set; }

    [Required(ErrorMessage = "Email er påkrævet.")]
    [EmailAddress(ErrorMessage = "Indtast en gyldig email-adresse.")]
    public string Email { get; set; }

    public Medlem(string navn, string telefonNummer, string email)
    {
        Id = Guid.NewGuid(); // Assign a unique ID
        Navn = navn;
        TelefonNummer = telefonNummer;
        Email = email;
    }

    public Medlem()
    {
        Id = Guid.NewGuid(); // Assign a unique ID
    }

    public override bool Equals(object obj)
    {
        if (obj is not Medlem other)
            return false;

        // Members are considered equal if their Id is the same
        return this.Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
