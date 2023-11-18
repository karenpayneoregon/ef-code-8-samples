namespace DateOnlyTimeOnlySampleApp.Models;

public class Term
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateOnly FirstDay { get; set; }
    public DateOnly LastDay { get; set; }
    public School School { get; set; } = null!;
}