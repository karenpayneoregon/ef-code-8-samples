namespace HasQueryFilterConditionalSample.Classes.Core;
/// <summary>
/// Represents the type of pill-shaped UI element, determining its visual style and color scheme.
/// </summary>
/// <remarks>
/// This enum is used in conjunction with the <see cref="Pill"/> class to define the appearance
/// of the pill when rendered in the console using Spectre.Console.
/// </remarks>
/// <summary>
/// Represents a success pill with a green background.
/// </summary>
/// <summary>
/// Represents a warning pill with a yellow background.
/// </summary>
/// <summary>
/// Represents an error pill with a red background.
/// </summary>
/// <summary>
/// Represents an informational pill with a blue background.
/// </summary>
public enum PillType
{
    Success,
    Warning,
    Error,
    Info,
    Pink
}