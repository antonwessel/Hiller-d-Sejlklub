using ClassLibrary.Interfaces;
using ClassLibrary.Models;

namespace ClassLibrary.Services;

public class MedlemService : IMedlemService
{
    private List<Medlem> _medlemList;

    public IJsonDataService<Medlem> JsonDataService { get; }

    public MedlemService(IJsonDataService<Medlem> jsonDataService)
    {
        _medlemList = MockData.MockMedlem.GetMembersAsList();
        JsonDataService = jsonDataService;
    }

    public void AddMedlem(Medlem medlem)
    {
        _medlemList.Add(medlem);
    }

    public Medlem DeleteMedlem(string? email)
    {
        Medlem medlemToDelete = _medlemList.FirstOrDefault(m => m.Email == email);
        if (medlemToDelete != null)
        {
            _medlemList.Remove(medlemToDelete);
        }
        return medlemToDelete;
    }

    public List<Medlem> FilterMembersByName(string name)
    {
        return _medlemList
            .Where(m => m.Navn.Contains(name, StringComparison.CurrentCultureIgnoreCase))
            .ToList();
    }

    public Medlem GetMedlem(string email)
    {
        return _medlemList.FirstOrDefault(m => m.Email == email);
    }

    public List<Medlem> GetMedlemmer() => _medlemList;

    public void UpdateMedlem(Medlem medlem)
    {
        var existingMedlem = _medlemList.FirstOrDefault(m => m.Email == medlem.Email);
        if (existingMedlem != null)
        {
            existingMedlem.Navn = medlem.Navn;
            existingMedlem.TelefonNummer = medlem.TelefonNummer;
        }
    }
}
