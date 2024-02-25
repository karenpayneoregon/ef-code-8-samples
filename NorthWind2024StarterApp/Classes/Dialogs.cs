namespace NorthWind2024StarterApp.Classes;

public class Dialogs
{
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

}
