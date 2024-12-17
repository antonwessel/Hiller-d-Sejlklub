using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Core.Models;

public class Blog
{
    [Required(ErrorMessage = "Titlen er påkrævet.")]
    [StringLength(100, ErrorMessage = "Titel må højst være 100 tegn.")]
    public string BlogTitel { get; set; }

    public DateTime BlogDato { get; set; }
    [Required(ErrorMessage = "Navn er påkrævet.")]
    [StringLength(50, ErrorMessage = "Navn må højst være 50 tegn.")]
    public string BlogForfatter { get; set; }

    [Required(ErrorMessage = "Indhold er påkrævet.")]
    [StringLength(5000, ErrorMessage = "Indhold må højst være 5000 tegn.")]
    public string BlogIndhold { get; set; }

    public Blog(string blogTitel, string blogForfatter, string blogIndhold, DateTime dateWritten)
    {
        // Mock data bruger den her
        BlogTitel = blogTitel;
        BlogDato = DateTime.Now;
        BlogForfatter = blogForfatter;
        BlogIndhold = blogIndhold;
        BlogDato = dateWritten;
    }

    public Blog()
    {
        // Razor Pages bruger den her constructor
        BlogDato = DateTime.Now;
    }
}
