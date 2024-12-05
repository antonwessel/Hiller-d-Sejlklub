using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Event
    {
        [Required(ErrorMessage = "Navn er påkrævet.")]
        [StringLength(100, ErrorMessage = "Navnet må ikke være længere end 100 tegn.")]
        public string Navn {  get; set; }
        [Required(ErrorMessage = "Dato er påkrævet.")]
        [DataType(DataType.Date, ErrorMessage = "Datoen skal være i et korrekt format.")]
        
        public DateTime Dato { get; set; }

        [Required(ErrorMessage = "Lokation er påkrævet.")]
        [StringLength(200, ErrorMessage = "Lokationen må ikke være længere end 200 tegn.")]
        public string Lokation {  get; set; }
       // public string Medlemmer {  get; set; } vi venter med det

        public Event(string navn, string dato, string lokation) 
        { 
            Navn = navn;
            Dato = DateTime.Now;
            Lokation = lokation;
            //Medlemmer = medlemmer;

        }

        public Event() { Dato = DateTime.Now; }

    }
}
