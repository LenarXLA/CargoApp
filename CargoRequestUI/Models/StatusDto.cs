using CargoRequestUI.Helper;
using System.ComponentModel;

namespace CargoRequestUI.Models;

public enum RequestStatusType
{
    [Description("Новая")]
    New,
    [Description("Передано на выполнение")]
    Submitted_for_execution,
    [Description("Выполнено")]
    Done,
    [Description("Отменена")]
    Cancelled
}
public class StatusDto
{
    public int Id { get; set; }
    public RequestStatusType StatusType { get; set; }

    public string Reason { get; set; }

    public bool IsEditable
    { 
        get
        {
            return StatusType == RequestStatusType.New;
        }
        set { }
    }

    public string Description 
    {
        get {
            EnumDescriptionConverter converter = new EnumDescriptionConverter();
            return converter.GetEnumDescription(StatusType);
        }
        set { }
    }
}