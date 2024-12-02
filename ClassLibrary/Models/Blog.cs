using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Blog
    {
        public string BlogTitel { get; set; }
        public DateTime BlogDato { get; set; }
        public string BlogForfatter { get; set; }
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
