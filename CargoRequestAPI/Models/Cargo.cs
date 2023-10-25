using System.ComponentModel.DataAnnotations.Schema;

namespace CargoRequestAPI.Models;

public class Cargo
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Сharacteristic { get; set; }
    public double? Weight { get; set; }
    public double? Volume { get; set; }
    public string? Dimensions { get; set; }
}