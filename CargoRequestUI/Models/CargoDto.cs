using System.Net;
using System.Xml.Linq;
using System;
using System.ComponentModel;
using System.Reflection.Metadata;

namespace CargoRequestUI.Models;

public class CargoDto : IDataErrorInfo
{
    public int Id { get; set; }
    public string? Сharacteristic { get; set; }
    public double? Weight { get; set; }
    public double? Volume { get; set; }
    public string? Dimensions { get; set; }

    public string this[string columnName]
    {
        get
        {
            string error = String.Empty;
            switch (columnName)
            {
                case "Сharacteristic":
                    int res1;
                    if (int.TryParse(Сharacteristic, out res1))
                    {
                        error = "Характеристика груза не должно быть просто цифрами";
                    }
                    break;
                //Здесь конечно каждый габарит лучше вычитывать отдельным полем
                case "Dimensions":
                    int res;
                    if (int.TryParse(Dimensions, out res))
                    {
                        error = "Габариты должны быть не просто цифрами, а соотношение в виде 1х1х1";
                    }
                    break;
                case "Weight":
                    if (!Weight.HasValue)
                    {
                        error = "Поле не должно быть пустым!";
                    }
                break;
                case "Volume":
                    if (!Volume.HasValue)
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