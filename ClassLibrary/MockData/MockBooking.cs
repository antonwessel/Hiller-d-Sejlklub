using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.MockData
{
    public class MockBooking
    {
        private static readonly List<Booking> _bookings = new()
        {
            new Booking(
                Guid.NewGuid(),
                DateTime.Now.AddDays(-2),
                MockMedlem.GetMembersAsList()[0], // Første medlem
                MockBåd.GetBoatsAsList()[0]      // Første båd
            ),
            new Booking(
                Guid.NewGuid(),
                DateTime.Now.AddDays(1),
                MockMedlem.GetMembersAsList()[1], // Andet medlem
                MockBåd.GetBoatsAsList()[1]      // Anden båd
            )
        };

        public static List<Booking> GetBookingsAsList() => _bookings;
    }
}
