using System.ComponentModel.DataAnnotations;
using Models.Domain;

namespace Models.DTO.AppointmentDTO
{
    public class AppointmentPATCH
    {        
        [Required]
        public long Id { get; set; }    
        public DateTime Date { get; set; }
        public string AppointmentStatus { get; set; } = string.Empty;
        public long StaffId { get; set; }
        public long PatientId { get; set; }   

    }
}