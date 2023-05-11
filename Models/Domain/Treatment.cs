using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Domain
{
    public class Treatment
    {
        [Key]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Diagnosis { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string DiagnosisCode { get; set; } = string.Empty;
        
        [Column(TypeName = "datetime")]
        public DateTime TreatmentDate { get; set; } = DateTime.Now;  
    }
}