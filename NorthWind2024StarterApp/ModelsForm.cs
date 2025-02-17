using System.ComponentModel;
using System.Text;
using NorthWind2024StarterApp.Classes;
using NorthWind2024StarterApp.Models.Utility;
// ReSharper disable AssignNullToNotNullAttribute
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace NorthWind2024StarterApp;
public partial class ModelsForm : Form
{
    private BindingList<EntityItem> _rootItems;
    private BindingSource _bindingSource = new();

    public ModelsForm()
    {
        InitializeComponent();
    }

    private void ModelsForm_Load(object sender, EventArgs e)
    {

        _rootItems = new BindingList<EntityItem>(EntityOperations.ModelDetails());

        _bindingSource.DataSource = _rootItems;
        ModelsComboBox.DataSource = _bindingSource;


        ModelsComboBox.SelectedIndexChanged += ModelsComboBox_SelectedIndexChanged;
        BuildModelDetailsText();
    }

    private void ModelsComboBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        BuildModelDetailsText();
    }

    private void BuildModelDetailsText()
    {
        StringBuilder builder = new();
        var current = (EntityItem)_bindingSource[ModelsComboBox.SelectedIndex];
        builder.AppendLine($"Model: {current.Name}");
        builder.AppendLine("Columns:");
        foreach (var column in current.Columns)
        {
            builder.AppendLine($"  {column.Name} ({column.Description})");
        }

        ResultsTextBox.Text = builder.ToString();
    }


    private void CurrentButton_Click(object sender, EventArgs e)
    {
        var current = (EntityItem)_bindingSource.Current;
    }
}
