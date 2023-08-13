using System.ComponentModel.DataAnnotations;
using Models.Domain;

namespace Models.DTO.AppointmentDTO
{
    public class AppointmentChangeStatus
    {   
        [Required]     
        public long Id { get; set; }    
        [Required]
        public string AppointmentStatus { get; set; } = string.Empty;
    }
}