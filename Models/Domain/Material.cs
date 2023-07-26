using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Domain
{
    public class Material
    {
        [Key]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string DiagnosisCode { get; set; } = string.Empty;
        
        [Column(TypeName = "datetime")]
        public DateTime TreatmentDate { get; set; } = DateTime.Now;

        public Staff? Staff { get; set; }
        public Patient? Patient { get; set; }
    }
}