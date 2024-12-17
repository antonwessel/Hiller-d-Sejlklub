using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Core.Models;

public class Member
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Navn er påkrævet.")]
    [StringLength(50, ErrorMessage = "Navn må ikke være længere end 50 tegn.")]
    public string Navn { get; set; }

    [Required(ErrorMessage = "Telefonnummer er påkrævet.")]
    [RegularExpression(@"^\d{8}$", ErrorMessage = "Telefonnummer skal være et gyldigt 8-cifret tal.")]
    public string TelefonNummer { get; set; }

    [Required(ErrorMessage = "Email er påkrævet.")]
    [EmailAddress(ErrorMessage = "Indtast en gyldig email-adresse.")]
    public string Email { get; set; }

    public Member(string navn, string telefonNummer, string email)
    {
        Id = Guid.NewGuid();
        Navn = navn;
        TelefonNummer = telefonNummer;
        Email = email;
    }

    public Member()
    {
        Id = Guid.NewGuid();
    }

    public override bool Equals(object obj)
    {
        if (obj is not Member other)
            return false;

        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
