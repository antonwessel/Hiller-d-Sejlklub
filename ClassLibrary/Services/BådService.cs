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
        foreach (var båd in _bådeListe)
        {
            if (båd.Navn == navn)
            {
                _bådeListe.Remove(båd);
                return båd;
            }
        }
        return null;
    }

    public Båd GetBåd(string navn)
    {
        foreach (var båd in _bådeListe)
        {
            if (båd.Navn == navn)
            {
                return båd;
            }
        }
        return null;
    }

    public List<Båd> GetBåde() => _bådeListe;

    public void UpdateBåd(Båd båd)
    {
        foreach (var bd in _bådeListe)
        {
            if (bd.Navn == båd.Navn)
            {
                bd.BådModel = båd.BådModel;
                bd.BådType = båd.BådType;
                break;
            }
        }
    }
}
