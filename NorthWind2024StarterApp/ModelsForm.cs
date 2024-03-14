using System.ComponentModel;
using NorthWind2024StarterApp.Classes;
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

    }

    private void CurrentButton_Click(object sender, EventArgs e)
    {
        var current = (EntityItem)_bindingSource.Current;
    }
}
