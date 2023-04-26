namespace Dental_App.Models.DTO.InvoiceDTO;
public class InvoiceGET
{
    public DateTime InvoiceDate {get;set;} = DateTime.Now;
    public float Amount {get;set;}
    public string Currency{get;set;} = string.Empty;
    public int IsPaid { get;set; } = 0;
    public float AmountRefused {get;set;}   
}