using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;

namespace ClassLibrary.Services;

public class BoatService : IBoatService
{
    private List<Boat> _boatList;
    private readonly IMaintenanceService _maintenanceService;

    public IJsonDataService<Boat> JsonDataService { get; }

    public BoatService(IMaintenanceService maintenanceService, IJsonDataService<Boat> jsonDataService)
    {
        _maintenanceService = maintenanceService;
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
        // forsøg at find en båd der matcher Name
        var boat = _boatList.FirstOrDefault(b => b.BoatName == name);
        if (boat != null)
        {
            _boatList.Remove(boat);
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
