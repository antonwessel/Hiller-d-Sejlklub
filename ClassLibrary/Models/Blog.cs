using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
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

        public Blog(string blogTitel, string blogForfatter, string blogIndhold)
        {
            BlogTitel = blogTitel;
            BlogDato = DateTime.Now;
            BlogForfatter = blogForfatter;
            BlogIndhold = blogIndhold;
        }

        public Blog()
        {

        }
    }
}
