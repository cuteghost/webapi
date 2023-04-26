using Dental_App.Models.Domain;

namespace Dental_App.Models.DTO.UserDTO.Patient;
public class PatientPOST : UserPost
{
    public User User { get; set; } = new User();
    public DateTime FirstVisitDate { get; set; } = DateTime.Today;
    public DateTime LastVisitDate { get; set; } = DateTime.Today;
    public string Adress { get; set; } = string.Empty;
    public DateTime LastPaymentDate { get; set; } = DateTime.Today;
    public string Telephone { get; set; } = string.Empty;
    public string Alergies { get; set; } = string.Empty;
    public string SpecialRequests { get; set; } = string.Empty;
    public string Perceptions { get; set; } = string.Empty;
}
