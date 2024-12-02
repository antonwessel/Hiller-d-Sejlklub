using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Begivenhed
    {
        public string Navn {  get; set; }
        public string Dato {  get; set; }
        public string Lokation {  get; set; }
        public string Medlemmer {  get; set; }

        public Begivenhed(string navn, string dato, string lokation, string medlemmer) 
        { 
            Navn = navn;
            Dato = dato;
            Lokation = lokation;
            Medlemmer = medlemmer;


        }
    }
}
