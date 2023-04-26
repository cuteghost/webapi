using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dental_App.Models.Domain;
public class Patient
{
    [Key]
    [Column(TypeName ="bigint")]
    public long PatientId { get; set; }
    public User User { get; set; } = new User();
    [Column(TypeName = "datetime")]
    public DateTime FirstVisitDate { get; set; } = DateTime.Today;
    [Column(TypeName = "datetime")]
    public DateTime LastVisitDate { get; set; } = DateTime.Today;
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(50)]
    public string Adress { get; set; } = string.Empty;
    [Column(TypeName = "datetime")]
    public DateTime LastPaymentDate { get; set; } = DateTime.Today;
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(20)]
    public string Telephone { get; set; } = string.Empty;
    [Column(TypeName = "nvarchar")]
    [MaxLength(4000)]
    public string Alergies { get; set; } = string.Empty;
    [Column(TypeName = "nvarchar")]
    [MaxLength(4000)]
    public string SpecialRequests { get; set; } = string.Empty;
    [Column(TypeName = "nvarchar")]
    [MaxLength(4000)]
    public string Perceptions { get; set; } = string.Empty;
}
