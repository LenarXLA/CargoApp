using System;
using System.ComponentModel;

namespace CargoRequestUI.Models;

public class CargoRequestDto : IDataErrorInfo
{
    public int Id { get; set; }
    public int ReqNumber { get; set; }
    public DateTime Date { get; set; }
    public StatusDto Status { get; set; }
    public SenderDto Sender { get; set; }
    public RecipientDto Recipient { get; set; }
    public CargoDto Cargo { get; set; }
    public string? Documents { get; set; }

    public string this[string columnName]
    {
        get
        {
            string error = String.Empty;
            switch (columnName)
            {
                case "Documents":
                    int res;
                    if (int.TryParse(Documents, out res))
                    {
                        error = "Документы должны быть не просто цифрами";
                    } 
                    else if (string.IsNullOrEmpty(Documents))
                    {
                        error = "Поле не должно быть пустым!";
                    }
                    break;
            }
            return error;
        }
    }
    public string Error
    {
        get { throw new NotImplementedException(); }
    }
}