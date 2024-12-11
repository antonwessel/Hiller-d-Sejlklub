using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using ClassLibrary.MockData;

namespace ClassLibrary.Services;

public class BådService : IBådService
{
    private List<Båd> _bådeListe;
    private readonly IMaintenanceService _maintenanceService;

    public IJsonDataService<Båd> JsonDataService { get; }

    public BådService(IMaintenanceService maintenanceService, IJsonDataService<Båd> jsonDataService)
    {
        _maintenanceService = maintenanceService;
        JsonDataService = jsonDataService;
        _bådeListe = jsonDataService.LoadData().ToList();

        foreach (var båd in _bådeListe)
        {
            foreach (var maintenance in båd.Maintenances)
            {
                _maintenanceService.AddMaintenance(båd.Navn, maintenance);
            }
        }
    }

    public void AddBåd(Båd båd)
    {
        _bådeListe.Add(båd);
        JsonDataService.SaveData(_bådeListe);
    }

    public Båd DeleteBåd(string? navn)
    {
        // forsøg at find en båd der matcher navn
        var båd = _bådeListe.FirstOrDefault(b => b.Navn == navn);
        if (båd != null)
        {
            _bådeListe.Remove(båd);
        }
        JsonDataService.SaveData(_bådeListe);
        return båd;
    }

    public Båd GetBåd(string navn) => _bådeListe.FirstOrDefault(b => b.Navn == navn);

    public List<Båd> GetBåde() => _bådeListe;

    public void UpdateBåd(Båd båd)
    {
        var existingBåd = _bådeListe.FirstOrDefault(b => b.Navn == båd.Navn);
        if (existingBåd != null)
        {
            existingBåd.BådModel = båd.BådModel;
            existingBåd.BådType = båd.BådType;
            existingBåd.BilledeUrl = båd.BilledeUrl;
        }
        JsonDataService.SaveData(_bådeListe);
    }
}
