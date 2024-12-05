using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models;

public class Maintenance
{
    [Required(ErrorMessage = "Skal have en beskrivelse")]
    public WorkStatus Status { get; set; }

    public DateTime Date { get; set; }

    [Required, StringLength(200, ErrorMessage = "Beskrivelsen må ikke være mere end 200 tegn")]
    public string Description { get; set; }

    public Guid MaintenanceId { get; set; }

    public Maintenance(WorkStatus status, string description)
    {
        Status = status;
        Date = DateTime.Now;
        Description = description;
        MaintenanceId = Guid.NewGuid();
    }

    public Maintenance()
    {
        Date = DateTime.Now;
        MaintenanceId = Guid.NewGuid();
    }

    public enum WorkStatus { Pending, WorkingOn, Done }
}
