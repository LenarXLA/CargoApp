using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CargoRequestAPI.Models;

public class CargoRequest
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public int ReqNumber { get; set; }
    public DateTime Date { get; set; }
    public Status Status { get; set; }
    public Sender Sender { get; set; }
    public Recipient Recipient { get; set; }
    public Cargo Cargo { get; set; }
    public string? Documents { get; set; }
    
}