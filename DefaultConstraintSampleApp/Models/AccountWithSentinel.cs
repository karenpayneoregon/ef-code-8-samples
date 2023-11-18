namespace DefaultConstraintSampleApp.Models;

public class AccountWithSentinel
{
    public int Id { get; set; }
    public bool IsActive { get; set; } = true;
}