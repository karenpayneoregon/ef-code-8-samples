using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using NorthWind2024StarterApp.Classes;
using NorthWind2024StarterApp.Components;
using NorthWind2024StarterApp.Data;
using NorthWind2024StarterApp.Models;

namespace NorthWind2024StarterApp;

public partial class Form1 : Form
{
    private BindingList<Category> _categoriesBindingList;
    private BindingSource _categoriesBindingSource = new();

    private SortableBindingList<Product> _productsBindingList;
    private BindingSource _productsBindingSource = new();

    public Form1()
    {
        InitializeComponent();
        Shown += Form1_Shown;
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.DataError += DataGridView1_DataError;
    }



    private async void Form1_Shown(object? sender, EventArgs e)
    {
        await using var context = new Context();

        /*
         * For each Category load known products and their supplier. If there is
         * a chance of products changing we need to not load products here, instead get
         * them when the category changes.
         */
        _categoriesBindingList = new BindingList<Category>(
            await context.Categories
                .Include(x => x.Products)
                .ThenInclude(x => x.Supplier).ToListAsync());

        _categoriesBindingSource.DataSource = _categoriesBindingList;
        CategoriesComboBox.DataSource = _categoriesBindingSource;
        CategoriesComboBox.SelectedIndexChanged += CategoriesComboBox_SelectedIndexChanged;

        GetProductsForSelectedCategory();
        _productsBindingSource.ListChanged += _productsBindingSource_ListChanged;
    }

    private void _productsBindingSource_ListChanged(object? sender, ListChangedEventArgs e)
    {
        if (e.ListChangedType == ListChangedType.ItemChanged)
        {

            Product product = _productsBindingList[_categoriesBindingSource.Position];

            /*
             * We have an edited product, recommend using FluentValidation NuGet package to validate
             * the current product.
             */
        }
        else if (e.ListChangedType == ListChangedType.ItemAdded)
        {
            // handle new product added
        }
        else if (e.ListChangedType == ListChangedType.ItemDeleted)
        {
            // handle product deleted
        }
    }

    private void CategoriesComboBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        GetProductsForSelectedCategory();
    }

    private void GetProductsForSelectedCategory()
    {
        Category category = _categoriesBindingList[CategoriesComboBox.SelectedIndex];
        _productsBindingList = new SortableBindingList<Product>(category.Products.ToList());
        _productsBindingSource.DataSource = _productsBindingList;
        dataGridView1.DataSource = _productsBindingSource;
        dataGridView1.ExpandColumns();
    }

    private void DataGridView1_DataError(object? sender, DataGridViewDataErrorEventArgs e)
    {
        MessageBox.Show($"Error\n{e.Exception!.Message}");
    }

    private void CurrentButton_Click(object sender, EventArgs e)
    {
        Category category = _categoriesBindingList[CategoriesComboBox.SelectedIndex];
        if (_productsBindingSource.Current is not null)
        {
            /*
             * Here we know the current Product
             */
            Product product = _productsBindingList[_productsBindingSource.Position];
        }
    }
}
