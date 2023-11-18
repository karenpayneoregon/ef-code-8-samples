namespace DefaultConstraintSampleApp.Models;

public class CourseWithSentinel
{
    public int Id { get; set; }
    public Level Level { get; set; } = Level.Unspecified;
}