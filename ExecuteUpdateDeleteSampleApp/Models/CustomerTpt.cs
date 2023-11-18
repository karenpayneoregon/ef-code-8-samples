using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteUpdateDeleteSampleApp.Models;
[Table("TptCustomers")]
public class CustomerTpt
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
[Table("TptSpecialCustomers")]
public class SpecialCustomerTpt : CustomerTpt
{
    public string? Note { get; set; }
}

