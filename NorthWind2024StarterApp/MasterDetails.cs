using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using NorthWind2024StarterApp.Classes;
using NorthWind2024StarterApp.Components;
using NorthWind2024StarterApp.Data;
using NorthWind2024StarterApp.Models;
using NorthWind2024StarterApp.Validators;
// ReSharper disable CollectionNeverQueried.Local
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace NorthWind2024StarterApp;
public partial class MasterDetails : Form
{
    private SortableBindingList<CustomerItem> _customersSortableBindingList;
    private BindingSource _customerBindingSource = new();

    private BindingSource _ordersBindingSource = new();

    private BindingSource _countryBindingSource = new();
    
    public MasterDetails()
    {
        InitializeComponent();

        // columns set in designer for both DataGridView controls
        CustomersDataGridView.AutoGenerateColumns = false;
        OrdersDataGridView.AutoGenerateColumns = false;

        Shown += MasterDetails_Shown;
    }

    private void MasterDetails_Shown(object? sender, EventArgs e)
    {
        using var context = new Context();

        _countryBindingSource.DataSource = context.Countries.ToList();

        var customers = context.Customers
            .AsNoTracking()
            .Include(c => c.CountryIdentifierNavigation)
            .Include(c => c.Orders)
            .Select(x => new CustomerItem()
            {
                CustomerIdentifier = x.CustomerIdentifier,
                CompanyName = x.CompanyName,
                CountryIdentifier = x.CountryIdentifier,
                CountryName = x.CountryIdentifierNavigation.Name,
                Orders = x.Orders

            }).ToList();


        /*
         * Set up Country dropdown
         */
        CountryColumn.DisplayMember = "Name";
        CountryColumn.ValueMember = "CountryIdentifier";
        CountryColumn.DataPropertyName = "CountryIdentifier";

        _customersSortableBindingList = new SortableBindingList<CustomerItem>(customers);
        _customerBindingSource.DataSource = _customersSortableBindingList;

        CustomersDataGridView.DataSource = _customerBindingSource;

        CountryColumn.DataSource = _countryBindingSource;

        // this ensures the dropdown does not show until needed
        CountryColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

        _customerBindingSource.PositionChanged += CustomerBindingSource_PositionChanged;

        _ordersBindingSource.DataSource = _customerBindingSource;
        _ordersBindingSource.DataMember = "Orders";

        OrdersDataGridView.DataSource = _ordersBindingSource;

        _customerBindingSource.ListChanged += _customerBindingSource_ListChanged;

        CustomersDataGridView.ExpandColumns();

        CustomersDataGridView.Sorted += CustomersDataGridView_Sorted;

        CustomersBindingNavigator.BindingSource = _customerBindingSource;


        SetupMasterBindingNavigatorAddRemoveButtons();

        OrdersDataGridView.DoubleClick += OrdersDataGridView_DoubleClick;
    }

    private void OrdersDataGridView_DoubleClick(object? sender, EventArgs e)
    {
        if (_ordersBindingSource.Current is not null)
        {
            var current = (Order)_ordersBindingSource.Current;
            using var context = new Context();
            List<OrderDetail> details = context
                .OrderDetails
                .AsNoTracking()
                .Include(x => x.Product)
                .ThenInclude(x => x.Category)
                .Where(x => x.OrderId == current.OrderId)
                .ToList();

            if (details is not null)
            {
                List<ProductItem> results = details
                    .Select(x => 
                        new ProductItem(
                            x.Product.ProductName, 
                            x.Product.Category, 
                            x.Product.UnitPrice, 
                            x.Quantity))
                    .ToList();
            }
        }
    }

    /// <summary>
    /// This is fragile, in regard to tool strip names per-say at first glance yet since .net core does not expose a BindingNavigator
    /// we are partly safe.
    /// </summary>
    private void SetupMasterBindingNavigatorAddRemoveButtons()
    {
        CustomersBindingNavigator.AddNewItem = null;
        CustomersBindingNavigator.Items["bindingNavigatorAddNewItem"].Click += CustomersAdd_Click;

        CustomersBindingNavigator.DeleteItem = null;
        CustomersBindingNavigator.Items["bindingNavigatorDeleteItem"].Click += CustomersDelete_Click1;
    }

    /*
     * Note that if cascading rules are not set correctly this will get an error from sql-server
     */
    private void CustomersDelete_Click1(object? sender, EventArgs e)
    {
        CustomerItem current = _customersSortableBindingList[_customerBindingSource.Position];

        if (Dialogs.Question(this, $"Remove {current.CompanyName}"))
        {
            
            using var context = new Context();
            var customer = context.Customers.FirstOrDefault(x => x.CustomerIdentifier == current.CustomerIdentifier);

            if (customer is not null)
            {
                context.Remove(customer);
                context.SaveChanges();
                _customerBindingSource.RemoveCurrent();
            }

        }
    }

    private void CustomersAdd_Click(object? sender, EventArgs e)
    {
        // TODO in dialog
    }

    /// <summary>
    /// Reset customer row after sort has finished.
    /// </summary>
    /// <remarks>
    /// We can not use the BindingSource Filter here
    /// </remarks>
    private void CustomersDataGridView_Sorted(object? sender, EventArgs e)
    {
        var list = (((IEnumerable)_customerBindingSource.DataSource).OfType<CustomerItem>()).ToList();
        var position = list.FindIndex(x => x.CustomerIdentifier == customerIdentifier);

        if (position > -1)
        {
            _customerBindingSource.Position = position;
        }

    }

    /// <summary>
    /// Starter code for handling changes to customers
    /// </summary>
    /// <param name="sender">Customer BindingSource</param>
    /// <param name="e"></param>
    private void _customerBindingSource_ListChanged(object? sender, ListChangedEventArgs e)
    {
        if (e.ListChangedType == ListChangedType.ItemChanged)
        {
            CustomerItem current = _customersSortableBindingList[_customerBindingSource.Position];
            Country? country = (Country)_countryBindingSource.Current;

            using var context = new Context();
            var customer = context.Customers.FirstOrDefault(x => x.CustomerIdentifier == current.CustomerIdentifier);

            if (customer != null)
            {
                CustomerItemValidator validator = new CustomerItemValidator();
                FluentValidation.Results.ValidationResult result = validator.Validate(current);

                if (result.IsValid)
                {
                    customer.CompanyName = current.CompanyName;
                    customer.CountryIdentifier = country.CountryIdentifier;
                    context.SaveChanges();
                }
                else
                {
                    current.CompanyName = customer.CompanyName;
                    MessageBox.Show(result.Errors.FirstOrDefault()!.ErrorMessage);
                }

            }

        }
        else if (e.ListChangedType == ListChangedType.ItemAdded)
        {
            // handle new product added
        }
        else if (e.ListChangedType == ListChangedType.ItemDeleted)
        {
            // handle product deleted or disallow via the DataGridView and allow only via the BindingNavigator
        }
    }

    // to keep track of current record for after sorting master DataGridView
    private int customerIdentifier = 1;
    private void CustomerBindingSource_PositionChanged(object? sender, EventArgs e)
    {
        CustomerItem current = _customersSortableBindingList[_customerBindingSource.Position];
        customerIdentifier = current.CustomerIdentifier;
    }
    
}