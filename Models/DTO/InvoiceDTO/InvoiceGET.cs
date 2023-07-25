using Models.Domain;

namespace Models.DTO.InvoiceDTO;
public class InvoiceGET
{
    public DateTime InvoiceDate {get;set;} = DateTime.Now;
    public float Amount {get;set;}
    public string Currency{get;set;} = string.Empty;
    public int IsPaid { get;set; } = 0;
    public float AmountRefused {get;set;}
    public string StaffName { get; set; } = string.Empty;
    //ovo je opcionalni parametar StaffDetails u slucaju
    //da je potrebno pokupiti jos neku informaciju sa stafa
    public string StaffDetails { get; set; } = string.Empty;
    //isto vazi i za pacijenta kao i za stafa
    public string PatientName { get; set; } = string.Empty;
    public string PatientDetails { get; set; } = string.Empty;
}