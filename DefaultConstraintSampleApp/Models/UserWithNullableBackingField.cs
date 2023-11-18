namespace DefaultConstraintSampleApp.Models;

public class UserWithNullableBackingField
{
    public int Id { get; set; }

    private int? _credits;

    public int Credits
    {
        get => _credits ?? 0;
        set => _credits = value;
    }
}