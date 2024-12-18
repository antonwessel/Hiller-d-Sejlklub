using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IBoatService
{
    List<Boat> GetBoats();

    void AddBoat(Boat boatToAdd);
    /// <summary>
    /// Opdaterer en båd med ny information.
    /// </summary>
    /// <param name="updatedBoat">Den opdaterede båd.</param>
    void UpdateBoat(Boat updatedBoat);

    Boat GetBoat(string boatName);
    Boat DeleteBoat(string? boatName);
    IJsonDataService<Boat> JsonDataService { get; }
}