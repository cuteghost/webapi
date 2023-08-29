using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Domain;

public class Location
{
    [Key]
    [Column(TypeName = "bigint")]
    public long Id { get; set; }
    [Required]
    public string Address { get; set; } = string.Empty;
    public long? CityId { get; set; }
    [ForeignKey("CityId")]
    public virtual City? City { get; set; }
}
