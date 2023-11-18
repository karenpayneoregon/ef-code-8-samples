namespace DefaultConstraintSampleApp.Models;

public class CourseWithNullableBackingField
{
    public int Id { get; set; }

    private Level? _level;

    public Level Level
    {
        get => _level ?? Level.Unspecified;
        set => _level = value;
    }
}