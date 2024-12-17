using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Core.Models;

public class Blog
{
    [Required(ErrorMessage = "Titlen er påkrævet.")]
    [StringLength(100, ErrorMessage = "Titel må højst være 100 tegn.")]
    public string BlogTitle { get; set; }

    public DateTime BlogDato { get; set; }

    [Required(ErrorMessage = "Forfatter er påkrævet.")]
    [StringLength(50, ErrorMessage = "Navn må højst være 50 tegn.")]
    public string BlogAuthor { get; set; }

    [Required(ErrorMessage = "Indhold er påkrævet.")]
    [StringLength(5000, ErrorMessage = "Indhold må højst være 5000 tegn.")]
    public string BlogContent { get; set; }

    public Blog(string blogTitle, string blogAuthor, string blogContent, DateTime dateWritten)
    {
        BlogTitle = blogTitle;
        BlogDato = DateTime.Now;
        BlogAuthor = blogAuthor;
        BlogContent = blogContent;
        BlogDato = dateWritten;
    }

    public Blog()
    {
        BlogDato = DateTime.Now;
    }
}
