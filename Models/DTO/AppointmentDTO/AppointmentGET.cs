using Models.Domain;

namespace Models.DTO.AppointmentDTO
{
    public class AppointmentGET
    {
        public long Id { get; set; }    
        public DateTime Date { get; set; }
        public string AppointmentStatus { get; set; } = string.Empty;
        public string StaffName { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
        public long PatientId { get; set; }
        public long StaffId { get; set; }
    }
}