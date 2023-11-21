using System.ComponentModel.DataAnnotations;

namespace ShadowProperties.Models;

#pragma warning disable CS0169
public class Report
{
    [Display(Name = "Id")]
    public int ContactId { get; set; }
    [Display(Name = "First")]
    public string FirstName { get; set; }
    [Display(Name = "Last")]
    public string LastName { get; set; }
    [Display(Name = "Last user")]
    public string LastUser { get; set; }
    [Display(Name = "Created by")]
    public string CreatedBy { get; set; }
    [Display(Name = "Created at")]
    public string CreatedAt { get; set; }
    [Display(Name = "Last update")]
    public string LastUpdated { get; set; }
    [Display(Name = "Deleted")]
    public string Deleted { get; set; }

    public override string ToString() => ContactId.ToString();

}