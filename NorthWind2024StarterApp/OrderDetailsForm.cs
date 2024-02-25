using NorthWind2024StarterApp.Classes;
using NorthWind2024StarterApp.Models;

namespace NorthWind2024StarterApp;
public partial class OrderDetailsForm : Form
{
    public OrderDetailsForm()
    {
        InitializeComponent();
    }

    public OrderDetailsForm(List<ProductItem> list, int orderId)
    {
        InitializeComponent();
        dataGridView1.DataSource = list;
        Text = $"Order details for order {orderId}";
        dataGridView1.ExpandColumns();
        dataGridView1.FixHeaders();
    }
}
