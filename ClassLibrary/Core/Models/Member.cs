using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Core.Models;

public class Member
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Name er påkrævet.")]
    [StringLength(50, ErrorMessage = "Name må ikke være længere end 50 tegn.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "PhoneNumber er påkrævet.")]
    [RegularExpression(@"^\d{8}$", ErrorMessage = "PhoneNumber skal være et gyldigt 8-cifret tal.")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Email er påkrævet.")]
    [EmailAddress(ErrorMessage = "Indtast en gyldig email-adresse.")]
    public string Email { get; set; }

    public Member(string name, string phoneNumber, string email)
    {
        Id = Guid.NewGuid();
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public Member()
    {
        Id = Guid.NewGuid();
    }

    //public override bool Equals(object obj)
    //{
    //    if (obj is not Member other)
    //        return false;

    //    return Id == other.Id;
    //}

    //public override int GetHashCode()
    //{
    //    return Id.GetHashCode();
    //}
}
