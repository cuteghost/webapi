using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Domain;
public class Invoice
{
    [Key]
    [Column(TypeName="bigint")]
    public long Id {get;set;}
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
    [Column(TypeName ="smallint")]
    public int IsPaid { get;set; } = 0;
    [Required]
    [Column(TypeName ="decimal(18,2)")]
    public float AmountRefused {get;set;}   

    public Staff? Staff { get; set; }
    public Patient? Patient { get; set; }


}