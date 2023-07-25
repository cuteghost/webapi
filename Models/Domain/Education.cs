using Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Domain;
public class Education
{
    [Key]
    [Column(TypeName = "bigint")]
    public long Id { get; set; }
    [Required]
    [Column(TypeName ="nvarchar(50)")]
    [MaxLength(50)]
    [MinLength(3)]
    public string Title { get; set; } = string.Empty;
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    [MaxLength(50)]
    [MinLength(3)]
    public string School { get; set; } = string.Empty;
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime From { get; set; } = DateTime.Now;
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime To { get; set; } = DateTime.Now;
    public Location? Location { get; set; }
    public long StaffId { get; set; }
}
