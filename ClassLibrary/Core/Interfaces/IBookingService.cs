﻿using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IBookingService
{
    Booking GetBooking(Båd boat);
    Booking GetBooking(Guid id);
    void AddParticipantToBooking(Medlem participant, Guid id, DateTime date);
    void AddBooking(Båd boat, Medlem medlem);
    void UpdateBooking(Booking booking);
    void DeleteBooking(Guid id);
    List<Booking> GetAllBookings(string bådNavn);
    IJsonDataService<Booking> JsonDataService { get; }


    List<Båd> GetAvailableBoats(List<Båd> allBoats, DateTime date); // Ny metode
}
