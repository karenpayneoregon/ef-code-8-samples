namespace DateBetweenApp.Interfaces;

public interface IBaseEvent
{
    int Id { get; set; }
    DateOnly? StartDate { get; set; }
    DateOnly? EndDate { get; set; }
}