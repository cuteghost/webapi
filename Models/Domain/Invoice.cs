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
    public DateTime CreatedDate {get;set;} = DateTime.Now.Date;
    [Required]
    [Column(TypeName ="datetime")]
    public DateTime DueDate {get;set;} = DateTime.Now;
    [Required]
    [Column(TypeName ="decimal(18,2)")]
    public float Amount {get;set;}
    [Column(TypeName ="nvarchar(max)")]
    public string Status { get;set; }
    public long? StaffId { get; set; } 
    public long? PatientId { get; set; }

    [ForeignKey("StaffId")]
    public virtual Staff? Staff { get; set; }
    [ForeignKey("PatientId")]
    public virtual Patient? Patient { get; set; }


}