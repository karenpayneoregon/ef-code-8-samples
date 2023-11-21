using System.ComponentModel.DataAnnotations;

namespace AccessEntityFramework.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string Description { get; set; }
    public List<Book> Books { get; set; }
}