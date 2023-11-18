namespace DefaultConstraintSampleApp.Models;

public class AccountWithNullableBackingField
{
    public int Id { get; set; }

    private bool? _isActive;

    public bool IsActive
    {
        get => _isActive ?? false;
        set => _isActive = value;
    }
}