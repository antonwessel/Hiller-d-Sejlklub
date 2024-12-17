using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IMaintenanceService
{
    List<Maintenance> GetMaintenances(string boatName);
    void AddMaintenance(string boatName, Maintenance maintenance);
    void UpdateMaintenance(string boatName, Maintenance maintenance);
    void DeleteMaintenance(string boatName, Maintenance maintenance);
    Maintenance GetMaintenance(string boatName, Guid maintenanceId);
    Dictionary<string, List<Maintenance>> LoadMaintenanceJsonData();
    void SaveMaintenanceJsonData(string boatName, List<Maintenance> maintenances);
    float GetMaintenancesDone(string boatName);
}
