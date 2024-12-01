using ClassLibrary.Interfaces;
using ClassLibrary.MockData;
using ClassLibrary.Models;

namespace ClassLibrary.Services;

public class BådService : IBådService
{
    private List<Båd> _bådeListe;

    public BådService()
    {
        _bådeListe = MockBåd.GetBoatsAsList();
    }

    public void AddBåd(Båd båd)
    {
        _bådeListe.Add(båd);
    }

    public Båd DeleteBåd(string? navn)
    {
        throw new NotImplementedException();
    }

    public Båd GetBåd(string navn)
    {
        throw new NotImplementedException();
    }

    public List<Båd> GetBåde() => _bådeListe;

    public void UpdateBåd(Båd båd)
    {
        throw new NotImplementedException();
    }
}
