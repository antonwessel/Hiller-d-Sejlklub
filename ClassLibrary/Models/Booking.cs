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

        
        
    }
}
