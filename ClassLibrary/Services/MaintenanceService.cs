using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;

namespace ClassLibrary.Services;

public class MaintenanceService : IMaintenanceService
{
    private readonly Dictionary<string, List<Maintenance>> _maintenanceData;
    private readonly IJsonDataService<Boat> _jsonBoatService;

    public MaintenanceService(IJsonDataService<Boat> jsonBoatService)
    {
        _jsonBoatService = jsonBoatService;

        // Henter vedligeholdelser fra JSON og laver en liste pr. båd
        _maintenanceData = LoadMaintenanceJsonData();
    }

    public Dictionary<string, List<Maintenance>> LoadMaintenanceJsonData()
    {
        var boats = _jsonBoatService.LoadData();
        var maintenanceData = new Dictionary<string, List<Maintenance>>();

        foreach (var boat in boats)
        {
            // Hvis båden ikke har vedligeholdelser, lav en tom liste
            maintenanceData[boat.BoatName] = boat.Maintenances ?? new List<Maintenance>();
        }

        return maintenanceData;
    }

    public void SaveMaintenanceJsonData(string boatName, List<Maintenance> maintenances)
    {
        var boats = _jsonBoatService.LoadData().ToList();
        var boat = boats.FirstOrDefault(b => b.BoatName == boatName);

        if (boat != null)
        {
            boat.Maintenances = maintenances;
            _jsonBoatService.SaveData(boats); // Gemmer ændringer til JSON
        }
    }

    public void AddMaintenance(string boatName, Maintenance maintenance)
    {
        if (!_maintenanceData.TryGetValue(boatName, out var maintenances))
        {
            // Hvis båden ikke findes i data, lav en ny liste
            maintenances = new List<Maintenance>();
            _maintenanceData[boatName] = maintenances;
        }

        // Undgå dubletter - Tjekker om vedligeholdelsen allerede findes
        if (!maintenances.Any(m => m.MaintenanceId == maintenance.MaintenanceId))
        {
            maintenances.Add(maintenance); // Tilføj ny vedligeholdelse
            SaveMaintenanceJsonData(boatName, maintenances); // Gem opdateret liste
        }
    }

    public void DeleteMaintenance(string boatName, Maintenance maintenance)
    {
        if (_maintenanceData.TryGetValue(boatName, out var maintenances))
        {
            var maintenanceToRemove = maintenances.FirstOrDefault(m => m.MaintenanceId == maintenance.MaintenanceId);
            if (maintenanceToRemove != null)
            {
                maintenances.Remove(maintenanceToRemove); // Fjerner vedligeholdelsen
                SaveMaintenanceJsonData(boatName, maintenances); // Gemmer ændringer
            }
        }
    }

    public Maintenance GetMaintenance(string boatName, Guid maintenanceId)
    {
        if (_maintenanceData.TryGetValue(boatName, out var maintenances))
        {
            // Finder en vedligeholdelse baseret på ID
            return maintenances.FirstOrDefault(m => m.MaintenanceId == maintenanceId);
        }

        return null; // Returnerer null, hvis vedligeholdelsen ikke findes
    }

    public List<Maintenance> GetMaintenances(string boatName)
    {
        return _maintenanceData.TryGetValue(boatName, out var maintenances)
            ? maintenances
            : []; // Returner tom liste, hvis ingen findes
    }

    public float GetMaintenancesDone(string boatName)
    {
        if (!_maintenanceData.TryGetValue(boatName, out var maintenances) || maintenances.Count == 0)
        {
            return 0f; // Returner 0%, hvis ingen vedligeholdelser findes
        }

        int total = maintenances.Count; // Samlet antal vedligeholdelser
        int done = maintenances.Count(m => m.Status == Maintenance.WorkStatus.Færdig); // Færdige vedligeholdelser

        return (float)done / total * 100; // Udregn procentdel af færdige vedligeholdelser
    }

    public void UpdateMaintenance(string boatName, Maintenance maintenance)
    {
        // Tjek om der findes vedligeholdelsesdata for båden
        if (_maintenanceData.TryGetValue(boatName, out var maintenances))
        {
            // Find vedligeholdelse med samme ID
            var index = maintenances.FindIndex(m => m.MaintenanceId == maintenance.MaintenanceId);
            if (index >= 0)
            {
                // Opdater vedligeholdelse
                maintenances[index] = maintenance;
                // Gem ændringer
                SaveMaintenanceJsonData(boatName, maintenances);
            }
        }
    }
}