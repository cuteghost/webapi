using Models.Domain;

namespace Models.DTO.InvoiceDTO;
public class InvoiceGET
{
    public long Id { get; set; }
    public DateTime CreatedDate {get;set;} = DateTime.Now;
    public float Amount {get;set;}
    public DateTime DueDate {get;set;} = DateTime.Now;
    public string Status { get;set; } = string.Empty;
    public string StaffName { get; set; } = string.Empty;
    public string StaffId { get; set; } = string.Empty;
    public string PatientName { get; set; } = string.Empty;
    public string PatientId { get; set; } = string.Empty;
}