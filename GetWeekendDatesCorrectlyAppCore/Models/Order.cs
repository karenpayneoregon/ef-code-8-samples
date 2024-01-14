
namespace GetWeekendDatesCorrectlyAppCore.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DeliveredDate { get; set; }
    public string Display => $"{DeliveredDate.DayOfWeek}";

}