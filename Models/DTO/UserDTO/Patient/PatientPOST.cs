using System.ComponentModel.DataAnnotations;
using Models.Domain;

namespace Models.DTO.UserDTO.Patient;
public class PatientPOST : UserPost
{
    public DateTime FirstVisitDate { get; set; } = DateTime.Today;
    public DateTime LastVisitDate { get; set; } = DateTime.Today;
    [MaxLength(50)]
    [MinLength(0)]
    public string Adress { get; set; } = string.Empty;
    public DateTime LastPaymentDate { get; set; } = DateTime.Today;
    [MaxLength(20)]
    [MinLength(8)]
    public string Telephone { get; set; } = string.Empty;
    [MaxLength(4000)]
    [MinLength(0)]
    public string Alergies { get; set; } = string.Empty;
    [MaxLength(4000)]
    [MinLength(0)]
    public string SpecialRequests { get; set; } = string.Empty;
    [MaxLength(4000)]
    [MinLength(0)]
    public string Perceptions { get; set; } = string.Empty;
}
