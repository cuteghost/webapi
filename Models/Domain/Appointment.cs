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
        public long? PatinetId { get; set; }
        public long? AcceptedBy { get; set; }    

    }
}