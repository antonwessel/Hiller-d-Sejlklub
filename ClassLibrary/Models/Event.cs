using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Event
    {
        public string Navn {  get; set; }
        public string Dato {  get; set; }
        public string Lokation {  get; set; }
       // public string Medlemmer {  get; set; } vi venter med det

        public Event(string navn, string dato, string lokation) 
        { 
            Navn = navn;
            Dato = dato;
            Lokation = lokation;
            //Medlemmer = medlemmer;

        }
    }
}
