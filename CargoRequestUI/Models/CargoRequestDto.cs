using System;

namespace CargoRequestUI.Models;

public class CargoRequestDto
{
    public int Id { get; set; }
    public int ReqNumber { get; set; }
    public DateTime Date { get; set; }
    public StatusDto Status { get; set; }
    public SenderDto Sender { get; set; }
    public RecipientDto Recipient { get; set; }
    public CargoDto Cargo { get; set; }
    public string? Documents { get; set; }
}