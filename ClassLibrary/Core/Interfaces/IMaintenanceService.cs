using ClassLibrary.Core.Models;

namespace ClassLibrary.Core.Interfaces;

public interface IMaintenanceService
{
    List<Maintenance> GetMaintenances(string boatName);
    void AddMaintenance(string boatName, Maintenance maintenanceToAdd);

    /// <summary>
    /// Opdaterer vedligeholdelse for en båd ved navn.
    /// </summary>
    /// <param name="boatName">Navnet på båden.</param>
    /// <param name="updatedMaintenance">Den opdaterede vedligeholdelse.</param>
    void UpdateMaintenance(string boatName, Maintenance updatedMaintenance);

    void DeleteMaintenance(string boatName, Maintenance maintenanceToDelete);
    Maintenance GetMaintenance(string boatName, Guid maintenanceId);
    Dictionary<string, List<Maintenance>> LoadMaintenanceJsonData();
    void SaveMaintenanceJsonData(string boatName, List<Maintenance> maintenances);
    float GetMaintenancesDone(string boatName);
}
