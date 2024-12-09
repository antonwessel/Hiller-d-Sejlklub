using ClassLibrary.Interfaces;
using ClassLibrary.Models;

namespace ClassLibrary.Services;

public class MedlemService : IMedlemService
{
    private List<Medlem> _medlemList;

    public MedlemService()
    {
        _medlemList = MockData.MockMedlem.GetMembersAsList();
    }

    public void AddMedlem(Medlem medlem)
    {
        _medlemList.Add(medlem);
    }

    public Medlem DeleteMedlem(string? email)
    {
        Medlem medlemToDelete = null;

        foreach (var medlem in _medlemList)
        {
            if (email == medlem.Email)
            {
                medlemToDelete = medlem;
                break;
            }
        }

        // to avoid null reference exception
        if (medlemToDelete != null)
        {
            _medlemList.Remove(medlemToDelete);
        }
        return medlemToDelete;
    }

    public List<Medlem> FilterMembersByName(string name)
    {
        // Return all members which matches 'name'
        return _medlemList.Where(m => m.Navn.Contains(name, StringComparison.CurrentCultureIgnoreCase)).ToList();
    }

    public Medlem GetMedlem(string email)
    {
        foreach (var medlem in _medlemList)
        {
            if (email == medlem.Email)
            {
                return medlem;
            }
        }
        return null;
    }

    public List<Medlem> GetMedlemmer() => _medlemList;

    public void UpdateMedlem(Medlem medlem)
    {
        // Email bruges som id og kan ikke ændres. Brug et ID, hvis email skal kunne ændres.
        foreach (var medle in _medlemList)
        {
            if (medle.Email == medlem.Email)
            {
                medle.Navn = medlem.Navn;
                medle.TelefonNummer = medlem.TelefonNummer;
                break;
            }
        }
    }
}

