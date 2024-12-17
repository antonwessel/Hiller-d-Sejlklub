using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;

namespace ClassLibrary.Services;

public class BoatService : IBoatService
{
    private readonly List<Boat> _boats;
    private readonly IMaintenanceService _maintenanceService;
    private readonly IBookingService _bookingService;

    public IJsonDataService<Boat> JsonDataService { get; }

    public BoatService(IMaintenanceService maintenanceService, IJsonDataService<Boat> jsonDataService, IBookingService bookingService)
    {
        _maintenanceService = maintenanceService;
        _bookingService = bookingService;
        JsonDataService = jsonDataService;

        _boats = jsonDataService.LoadData().ToList();

        LoadMaintenances(); // Tilføjer vedligeholdelse for hver båd
    }

    public void AddBoat(Boat boatToAdd)
    {
        _boats.Add(boatToAdd);
        JsonDataService.SaveData(_boats);
    }

    public Boat DeleteBoat(string boatName)
    {
        var boatToDelete = _boats.FirstOrDefault(boat => boat.BoatName == boatName);
        if (boatToDelete != null)
        {
            _boats.Remove(boatToDelete);

            DeleteBookings(boatName); // Fjerner bookinger for båden

            JsonDataService.SaveData(_boats);
        }
        return boatToDelete;
    }

    public Boat GetBoat(string boatName) => _boats.FirstOrDefault(boat => boat.BoatName == boatName);

    public List<Boat> GetBoats() => _boats;

    public void UpdateBoat(Boat updatedBoat)
    {
        var existingBoat = _boats.FirstOrDefault(b => b.BoatName == updatedBoat.BoatName);
        if (existingBoat != null)
        {
            existingBoat.BoatModel = updatedBoat.BoatModel;
            existingBoat.BoatType = updatedBoat.BoatType;
            existingBoat.ImageURL = updatedBoat.ImageURL;
            JsonDataService.SaveData(_boats);
        }
    }

    private void LoadMaintenances()
    {
        foreach (var boat in _boats)
        {
            foreach (var maintenance in boat.Maintenances)
            {
                _maintenanceService.AddMaintenance(boat.BoatName, maintenance);
                // Tilføjer vedligeholdelse til service
            }
        }
    }

    private void DeleteBookings(string boatName)
    {
        var bookings = _bookingService.GetAllBookings(boatName);
        foreach (var booking in bookings)
        {
            _bookingService.DeleteBooking(booking.Id);
            // Sletter alle bookinger for båden
        }
    }
}
