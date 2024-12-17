using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IBoatService
{
    List<Boat> GetBoats();
    void AddBoat(Boat boat);
    void UpdateBoat(Boat boat);
    Boat GetBoat(string name);
    Boat DeleteBoat(string? name);
    IJsonDataService<Boat> JsonDataService { get; }
}