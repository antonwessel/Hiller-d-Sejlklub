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
        throw new NotImplementedException();
    }

    public Medlem DeleteMedlem(string? email)
    {
        throw new NotImplementedException();
    }

    public Medlem GetMedlem(string email)
    {
        throw new NotImplementedException();
    }

    public List<Medlem> GetMedlemmer() => _medlemList;


    public void UpdateMedlem(Medlem medlem)
    {
        throw new NotImplementedException();
    }
}
