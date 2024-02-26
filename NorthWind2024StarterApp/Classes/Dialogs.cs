namespace NorthWind2024StarterApp.Classes;

/// <summary>
/// Custom dialogs
/// </summary>
/// <remarks>
/// Both use images from project resources, with standard images
/// the dialog emits a beep.
/// </remarks>
public class Dialogs
{
    /// <summary>
    /// For asking a question with No as the default button
    /// </summary>
    /// <param name="owner">Control to center on</param>
    /// <param name="heading">Text to display</param>
    /// <returns>true or false</returns>
    public static bool Question(Control owner, string heading)
    {

        TaskDialogButton yesButton = new("Yes") { Tag = DialogResult.Yes };
        TaskDialogButton noButton = new("No") { Tag = DialogResult.No };

        var buttons = new TaskDialogButtonCollection
        {
            noButton,
            yesButton
        };

        TaskDialogPage page = new()
        {
            Caption = "Question",
            SizeToContent = true,
            Heading = heading,
            Icon = new TaskDialogIcon(Properties.Resources.QuestionBlue),
            Buttons = buttons
        };

        var result = TaskDialog.ShowDialog(owner, page);

        return (DialogResult)result.Tag! == DialogResult.Yes;

    }
    /// <summary>
    /// A better alert
    /// </summary>
    /// <param name="owner">Control to center on</param>
    /// <param name="heading">Heading text or an empty string</param>
    /// <param name="text">Text to display</param>
    /// <param name="buttonText">To override OK as the button text</param>
    public static void Information(Control owner, string heading, string text, string buttonText = "Ok")
    {

        TaskDialogButton okayButton = new(buttonText);

        TaskDialogPage page = new()
        {
            Caption = "Information",
            SizeToContent = true,
            Heading = heading,
            Footnote = new TaskDialogFootnote() { Text = "Code sample by Karen Payne" },
            Text = text,
            Icon = new TaskDialogIcon(Properties.Resources.blueInformation_32),
            Buttons = [okayButton]
        };

        TaskDialog.ShowDialog(owner, page);

    }

}
