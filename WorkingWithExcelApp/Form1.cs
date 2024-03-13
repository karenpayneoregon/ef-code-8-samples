using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using WorkingWithExcelApp.Classes;
using WorkingWithExcelApp.Data;
using WorkingWithExcelApp.Models;

namespace WorkingWithExcelApp;

public partial class Form1 : Form
{
    private SortableBindingList<Customers> _customers;
    private BindingSource _bindingSource = new();
    public Form1()
    {
        InitializeComponent();
        dataGridView1.AutoGenerateColumns = false;
    }

    private void ReadSheetButton_Click(object sender, EventArgs e)
    {

        _customers = new SortableBindingList<Customers>(ExcelOperations.ReadSheet());
        _bindingSource.DataSource = _customers;
        dataGridView1.DataSource = _bindingSource;
        dataGridView1.ExpandColumns();

    }

    private void DetailsButton_Click(object sender, EventArgs e)
    {
        ExcelOperations.ShowDetails();
    }

    private void CurrentCustomerButton_Click(object sender, EventArgs e)
    {
        if (_customers is null) return;

        if (_bindingSource.Current is Customers current)
        {
            Dialogs.Information(this, "",
                $"Id {current!.CustomerIdentifier} " +
                $"Modified {current.ModifiedDate} " +
                $"Contact type {current.ContactTypeIdentifier}");
        }

    }
}