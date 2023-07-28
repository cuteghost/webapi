using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FluentNHibernate.Conventions.Inspections;
using Microsoft.EntityFrameworkCore;
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
        public long StaffId { get; set; }
        public long PatientId { get; set; }
        
        [ForeignKey("StaffId")]
        public Staff? Staff { get; set; }
        
        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }   
    }
}