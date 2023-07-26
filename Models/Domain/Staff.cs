using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Domain;

public class Staff
{
    [Key]
    [Column(TypeName ="bigint")]
    public long StaffId { get; set; }
    [Required]
    public User User { get; set; } = new User();
    [Column(TypeName = "datetime")]
    public DateTime Joined { get; set; } = DateTime.Today;

    [Column(TypeName = "nvarchar")]
    [MaxLength(4000)]
    public string Languages { get; set; } = string.Empty;
}
