using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AccessEntityFramework.Models;

public class Book
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    [Precision(precision: 10, scale: 2)] 
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public override string ToString() => Title;
}