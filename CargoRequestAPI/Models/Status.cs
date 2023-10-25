using System.ComponentModel.DataAnnotations.Schema;

namespace CargoRequestAPI.Models;

public enum RequestStatusType
{
    New,
    Submitted_for_execution,
    Done,
    Cancelled
}

public class Status
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public RequestStatusType StatusType { get; set; }
    public string Reason { get; set; }
}