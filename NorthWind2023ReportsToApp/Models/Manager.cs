
using NorthWind2023Library.Models;

namespace NorthWind2023ReportsToApp.Models
{
    public class Manager
    {
        public Employees Employee { get; set; }
        public List<Employees> Workers { get; set; } = new();
    }
}