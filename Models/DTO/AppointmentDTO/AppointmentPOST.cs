using Models.Domain;

namespace Models.DTO.AppointmentDTO
{
    public class AppointmentPOST
    {        
        public DateTime Date { get; set; }
        public string AppointmentStatus { get; set; } = string.Empty;
        public long StaffId { get; set; }
        public long PatientId { get; set; }   
    }
}