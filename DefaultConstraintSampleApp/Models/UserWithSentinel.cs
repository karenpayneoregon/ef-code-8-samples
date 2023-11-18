namespace DefaultConstraintSampleApp.Models;

public class UserWithSentinel
{
    public int Id { get; set; }
    public int Credits { get; set; } = -1;
}