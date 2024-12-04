using ClassLibrary.Interfaces;
using ClassLibrary.Models;

namespace ClassLibrary.Services;

public class MaintenanceService : IMaintenanceService
{
    private readonly Dictionary<string, List<Maintenance>> _maintenanceData;
    // key er båd navn og hver værdi er en liste af vedligeholdelser

    public MaintenanceService()
    {
        _maintenanceData = [];
    }

    public void AddMaintenance(string bådNavn, Maintenance maintenance)
    {
        // Hvis båden ikke er i listen, opret en ny tom liste. Ellers tilføj vedligeholdelsen.
        if (!_maintenanceData.TryGetValue(bådNavn, out List<Maintenance>? value))
        {
            value = ([]);
            _maintenanceData[bådNavn] = value;
        }
        value.Add(maintenance);
    }

    public void DeleteMaintenance(string bådNavn, Maintenance maintenance)
    {
        // Prøv at find listen af vedligeholdelser på den rigtige båd
        if (_maintenanceData.TryGetValue(bådNavn, out var maintenances))
        {
            // Fjern alle de vedligeholdelser som matcher den vedligeholdelse vi gerne vil fjerne
            maintenances.RemoveAll(m =>
                m.Date == maintenance.Date &&
                m.Description == maintenance.Description &&
                m.Status == maintenance.Status);
        }
    }

    public Maintenance GetMaintenance(string bådNavn, Guid maintenanceId)
    {
        List<Maintenance> maintenancesForBoat = GetMaintenances(bådNavn);
        foreach (var maintenance in maintenancesForBoat)
        {
            if (maintenance.MaintenanceId == maintenanceId)
            {
                return maintenance;
            }
        }
        return null;
    }

    public List<Maintenance> GetMaintenances(string bådNavn)
    {
        // prøv at få listen af vedligeholdelser baseret på bådNavn
        if (_maintenanceData.TryGetValue(bådNavn, out var maintenances))
        {
            return maintenances;
        }
        return [];
    }

    public void UpdateMaintenance(string bådNavn, Maintenance maintenance)
    {
        if (_maintenanceData.TryGetValue(bådNavn, out var maintenances))
        {
            // Find det indeks i listen som matcher Id
            var index = maintenances.FindIndex(m => m.MaintenanceId == maintenance.MaintenanceId);
            if (index >= 0)
            {
                // Erstat (opdater) gamle med nye vedligeholdelse
                maintenances[index] = maintenance;
            }
        }
    }
}
