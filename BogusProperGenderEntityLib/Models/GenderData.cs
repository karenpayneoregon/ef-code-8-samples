using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace BogusProperGenderEntityLib.Models;

[Table("Gender")]
public class GenderData
{
    /// <summary>
    /// Gets or sets the ID of the gender.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the gender.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the gender.
    /// </summary>
    public string Description { get; set; }
}
