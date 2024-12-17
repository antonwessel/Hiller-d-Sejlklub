﻿using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;

namespace ClassLibrary.Services;

public class BådService : IBoatService
{
    private List<Boat> _bådeListe;
    private readonly IMaintenanceService _maintenanceService;

    public IJsonDataService<Boat> JsonDataService { get; }

    public BådService(IMaintenanceService maintenanceService, IJsonDataService<Boat> jsonDataService)
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

    public void AddBoat(Boat båd)
    {
        _bådeListe.Add(båd);
        JsonDataService.SaveData(_bådeListe);
    }

    public Boat DeleteBoat(string? navn)
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

    public Boat GetBoat(string navn) => _bådeListe.FirstOrDefault(b => b.Navn == navn);

    public List<Boat> GetBoats() => _bådeListe;

    public void UpdateBoat(Boat båd)
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
