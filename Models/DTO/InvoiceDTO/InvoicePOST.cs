using Models.DTO.UserDTO.Patient;
using Models.DTO.UserDTO.Staff;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.DTO.InvoiceDTO;
public class InvoicePOST
{
    [Required]
    [Column(TypeName ="datetime")]
    public DateTime CreatedDate {get;set;} = DateTime.Now.Date;
    [Required]
    [Column(TypeName ="datetime")]
    public DateTime DueDate {get;set;} = DateTime.Now.Date;
    [Required]
    [Column(TypeName ="decimal(18,2)")]
    public float Amount {get;set;}
    public string Status { get; set; }
    public long StaffId { get; set; }
    public long PatientId { get; set; }

}