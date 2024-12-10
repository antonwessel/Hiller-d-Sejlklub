using ClassLibrary.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Booking
    {
        private Guid guid;
        private DateTime dateTime;
        private Medlem medlem;
        private Båd båd;

        public Booking(Guid guid, DateTime dateTime, Medlem medlem, Båd båd)
        {
            this.guid = guid;
            this.dateTime = dateTime;
            this.medlem = medlem;
            this.båd = båd;
        }

        // Overvej at brug auto properties. Lige nu kan man ikke få fat på dataen udefra. Id kan også bare oprettes inde i constructor. Såsom dette...

        //public Guid Id { get; set; }
        //public DateTime DateBooked { get; set; }
        //public Medlem MedlemToBook { get; set; }
        //public Båd BoatToBook { get; set; }

        //public Booking(DateTime date, Medlem medlem, Båd boat)
        //{
        //    Id = Guid.NewGuid();
        //    DateBooked = date;
        //    MedlemToBook = medlem;
        //    BoatToBook = boat;
        //}



    }
}
