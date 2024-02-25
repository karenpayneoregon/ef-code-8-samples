#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind2024StarterApp.Models;
public class CustomerItem : INotifyPropertyChanged
{
    private int _customerIdentifier;
    private string _companyName;
    private int? _countryIdentifier;
    private string _countryName;
    private List<Order> _orders = new List<Order>();

    public int CustomerIdentifier
    {
        get => _customerIdentifier;
        set
        {
            if (value == _customerIdentifier) return;
            _customerIdentifier = value;
            OnPropertyChanged();
        }
    }

    public string CompanyName
    {
        get => _companyName;
        set
        {
            if (value == _companyName) return;
            _companyName = value;
            OnPropertyChanged();
        }
    }

    public int? CountryIdentifier
    {
        get => _countryIdentifier;
        set
        {
            if (value == _countryIdentifier) return;
            _countryIdentifier = value;
            OnPropertyChanged();
        }
    }

    public string CountryName
    {
        get => _countryName;
        set
        {
            if (value == _countryName) return;
            _countryName = value;
            OnPropertyChanged();
        }
    }

    public virtual List<Order> Orders
    {
        get => _orders;
        set
        {
            if (Equals(value, _orders)) return;
            _orders = value;
            OnPropertyChanged();
        }
    }

    public override string ToString() => CompanyName;

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
