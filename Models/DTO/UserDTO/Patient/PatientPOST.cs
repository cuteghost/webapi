using System.ComponentModel.DataAnnotations;
using Models.Domain;

namespace Models.DTO.UserDTO.Patient;
public class PatientPOST : UserPost
{
    [MaxLength(50)]
    [MinLength(0)]
    public string Adress { get; set; } = string.Empty;
    [MaxLength(20)]
    [MinLength(8)]
    public string Telephone { get; set; } = string.Empty;

}
