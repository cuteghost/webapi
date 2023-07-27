using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Domain
{
    public class Appointment
    {
        [Key]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }    
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public DateTime Date { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string AppointmentStatus { get; set; } = string.Empty;

        public Staff? Staff { get; set; }
        public Patient? Patient { get; set; }   
    }
}