using Models.Domain;

namespace Models.DTO.UserDTO.Patient;

public class PatientGET : UserGet
{
    public string? Adress { get; set; }
    public string? Telephone { get; set; }
    public long PatientId { get; set; }

}

public class PatientObjectGET 
{

    public long PatientId { get; set; }
    public User User { get; set; }
    public DateTime FirstVisitDate { get; set; } = DateTime.Today;
    public DateTime LastVisitDate { get; set; } = DateTime.Today;
    public string Adress { get; set; } = string.Empty;
    public DateTime LastPaymentDate { get; set; } = DateTime.Today;
    public string Telephone { get; set; } = string.Empty;
    public string Alergies { get; set; } = string.Empty;
    public string SpecialRequests { get; set; } = string.Empty;
    public string Perceptions { get; set; } = string.Empty;
}
