using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IMedlemService
{
    List<Medlem> GetMedlemmer();
    void AddMedlem(Medlem medlem);
    void UpdateMedlem(Medlem medlem);
    Medlem GetMedlem(string email);
    Medlem GetMedlem(Guid id);
    Medlem DeleteMedlem(string? email);
    List<Medlem> FilterMembersByName(string name); // Brugt til søge funktion
    IJsonDataService<Medlem> JsonDataService { get; }
}
