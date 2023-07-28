using Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Domain;
public class Experience
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
    public string WorkPlace { get; set; } = string.Empty;
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime From { get; set; } = DateTime.Now;
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime To { get; set; } = DateTime.Now;
    public Location? Location { get; set; }
    
    public Staff? Staff { get; set; }
}