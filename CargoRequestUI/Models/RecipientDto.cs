using System;
using System.ComponentModel;

namespace CargoRequestUI.Models;

public class RecipientDto : IDataErrorInfo
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }

    public string this[string columnName]
    {
        get
        {
            string error = String.Empty;
            switch (columnName)
            {
                case "Name":
                    int res1;
                    if (int.TryParse(Name, out res1))
                    {
                        error = "Имя не должно быть просто цифрами";
                    }
                    else if (string.IsNullOrEmpty(Name))
                    {
                        error = "Поле не должно быть пустым!";
                    }
                    break;
                case "Address":
                    int res2;
                    if (int.TryParse(Address, out res2))
                    {
                        error = "Неверный адрес";
                    }
                    else if (string.IsNullOrEmpty(Address))
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
        get
        {
            return string.Empty;
        }
    }
}