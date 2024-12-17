using ClassLibrary.Core.Interfaces;
using ClassLibrary.Core.Models;
using System.Linq;

public class MaintenanceService : IMaintenanceService
{
    private readonly Dictionary<string, List<Maintenance>> _maintenanceData;
    private readonly IJsonDataService<Boat> _jsonBoatService;

    public MaintenanceService(IJsonDataService<Boat> jsonBoatService)
    {
        _jsonBoatService = jsonBoatService;
        _maintenanceData = LoadMaintenanceJsonData();
    }

    public Dictionary<string, List<Maintenance>> LoadMaintenanceJsonData()
    {
        var boats = _jsonBoatService.LoadData();
        var maintenanceData = new Dictionary<string, List<Maintenance>>();

        foreach (var boat in boats)
        {
            maintenanceData[boat.BoatName] = boat.Maintenances ?? [];
        }

        return maintenanceData;
    }

    public void SaveMaintenanceJsonData(string Name, List<Maintenance> maintenances)
    {
        var boats = _jsonBoatService.LoadData().ToList();
        var boat = boats.FirstOrDefault(b => b.BoatName == Name);
        if (boat != null)
        {
            boat.Maintenances = maintenances;
            _jsonBoatService.SaveData(boats);
        }
    }

    public void AddMaintenance(string Name, Maintenance maintenance)
    {
        if (!_maintenanceData.TryGetValue(Name, out var maintenances))
        {
            // Hvis båden ikke findes, opret en ny liste
            maintenances = [];
            _maintenanceData[Name] = maintenances;
        }

        // Tjek for at undgå kopier
        if (!maintenances.Any(m => m.MaintenanceId == maintenance.MaintenanceId))
        {
            maintenances.Add(maintenance);
            SaveMaintenanceJsonData(Name, maintenances);
        }
    }

    public void DeleteMaintenance(string Name, Maintenance maintenance)
    {
        if (_maintenanceData.TryGetValue(Name, out var maintenances))
        {
            // Find den vedligeholdelse, der skal slettes
            var maintenanceToRemove = maintenances.FirstOrDefault(m => m.MaintenanceId == maintenance.MaintenanceId);
            if (maintenanceToRemove != null)
            {
                maintenances.Remove(maintenanceToRemove);
                SaveMaintenanceJsonData(Name, maintenances);
            }
        }
    }

    public Maintenance GetMaintenance(string Name, Guid maintenanceId)
    {
        // Tjekker om der findes vedligeholdelser for den givne båd
        if (_maintenanceData.TryGetValue(Name, out var maintenances))
        {
            // Gennemgår listen for at finde vedligeholdelsen med det specifikke ID
            foreach (var maintenance in maintenances)
            {
                if (maintenance.MaintenanceId == maintenanceId)
                {
                    return maintenance;
                }
            }
        }

        return null;
    }

    public List<Maintenance> GetMaintenances(string Name)
    {
        // Tjekker om der findes vedligeholdelser for den givne båd
        if (_maintenanceData.TryGetValue(Name, out var maintenances))
        {
            return maintenances;
        }

        return [];
    }


    public float GetMaintenancesDone(string Name)
    {
        if (!_maintenanceData.TryGetValue(Name, out var maintenances) || maintenances.Count == 0)
        {
            return 0f; // Returner 0%, hvis ingen vedligeholdelser findes
        }

        int total = maintenances.Count;
        int done = maintenances.Count(m => m.Status == Maintenance.WorkStatus.Færdig);

        return ((float)done / total) * 100;
    }

    public void UpdateMaintenance(string Name, Maintenance maintenance)
    {
        if (_maintenanceData.TryGetValue(Name, out var maintenances))
        {
            // Find indeks for den vedligeholdelse, der skal opdateres
            var index = maintenances.FindIndex(m => m.MaintenanceId == maintenance.MaintenanceId);
            if (index >= 0)
            {
                maintenances[index] = maintenance;
                SaveMaintenanceJsonData(Name, maintenances);
            }
        }
    }
}
