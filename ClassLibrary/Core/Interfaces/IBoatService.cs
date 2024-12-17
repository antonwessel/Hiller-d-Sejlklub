using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IBoatService
{
    List<Boat> GetBoats();
    void AddBoat(Boat boatToAdd);
    void UpdateBoat(Boat updatedBoat);
    Boat GetBoat(string boatName);
    Boat DeleteBoat(string? boatName);
    IJsonDataService<Boat> JsonDataService { get; }
}