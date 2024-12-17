using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IMaintenanceService
{
    List<Maintenance> GetMaintenances(string Name);
    void AddMaintenance(string Name, Maintenance maintenance);
    void UpdateMaintenance(string Name, Maintenance maintenance);
    void DeleteMaintenance(string Name, Maintenance maintenance);
    Maintenance GetMaintenance(string Name, Guid maintenanceId);
    Dictionary<string, List<Maintenance>> LoadMaintenanceJsonData();
    void SaveMaintenanceJsonData(string Name, List<Maintenance> maintenances);
    float GetMaintenancesDone(string Name);
}
