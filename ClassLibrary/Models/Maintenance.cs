namespace ClassLibrary.Models;

public class Maintenance
{
    public WorkStatus Status { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }

    public Maintenance(WorkStatus status, string description)
    {
        Status = status;
        Date = DateTime.Now;
        Description = description;
    }

    public Maintenance()
    {
        Date = DateTime.Now;
    }

    public enum WorkStatus { Pending, WorkingOn, Done }
}
