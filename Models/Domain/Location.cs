using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Domain;

public class Location
{
    [Key]
    [Column(TypeName = "bigint")]
    public long Id { get; set; }
    [Required]
    public string Country { get; set; } = string.Empty;
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string City { get; set; } = string.Empty;
    [Column(TypeName = "nvarchar(max)")]
    [Required]
    public string Address { get; set; } = string.Empty;
}
