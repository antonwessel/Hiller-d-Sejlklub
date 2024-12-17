using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;

namespace ClassLibrary.Services;

public class BoatService : IBoatService
{
    private readonly List<Boat> _boatList;
    private readonly IMaintenanceService _maintenanceService;
    private readonly IBookingService _bookingService;

    public IJsonDataService<Boat> JsonDataService { get; }

    public BoatService(IMaintenanceService maintenanceService, IJsonDataService<Boat> jsonDataService, IBookingService bookingService)
    {
        _maintenanceService = maintenanceService;
        _bookingService = bookingService;
        JsonDataService = jsonDataService;
        _boatList = jsonDataService.LoadData().ToList();

        foreach (var boat in _boatList)
        {
            foreach (var maintenance in boat.Maintenances)
            {
                _maintenanceService.AddMaintenance(boat.BoatName, maintenance);
            }
        }
    }

    public void AddBoat(Boat boat)
    {
        _boatList.Add(boat);
        JsonDataService.SaveData(_boatList);
    }

    public Boat DeleteBoat(string? name)
    {
        // Attempt to find a boat that matches the name
        var boat = _boatList.FirstOrDefault(b => b.BoatName == name);
        if (boat != null)
        {
            _boatList.Remove(boat);
            // Remove associated bookings
            var bookings = _bookingService.GetAllBookings(name);
            foreach (var booking in bookings)
            {
                _bookingService.DeleteBooking(booking.Id);
            }
        }
        JsonDataService.SaveData(_boatList);
        return boat;
    }

    public Boat GetBoat(string name) => _boatList.FirstOrDefault(b => b.BoatName == name);

    public List<Boat> GetBoats() => _boatList;

    public void UpdateBoat(Boat boat)
    {
        var existingBoat = _boatList.FirstOrDefault(b => b.BoatName == boat.BoatName);
        if (existingBoat != null)
        {
            existingBoat.BoatModel = boat.BoatModel;
            existingBoat.BoatType = boat.BoatType;
            existingBoat.ImageURL = boat.ImageURL;
        }
        JsonDataService.SaveData(_boatList);
    }
}
