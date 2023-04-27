using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.DTO.InvoiceDTO;
public class InvoicePOST
{
    [Required]
    [Column(TypeName ="datetime")]
    public DateTime InvoiceDate {get;set;} = DateTime.Now;
    [Required]
    [Column(TypeName ="decimal(18,2)")]
    public float Amount {get;set;}
    [Required]
    [Column(TypeName ="nvarchar")]
    [MaxLength(10)]
    [MinLength(1)]
    public string Currency{get;set;} = string.Empty;
    [Required]
    [Column(TypeName ="decimal(18,2)")]
    public float AmountRefused {get;set;}   

}