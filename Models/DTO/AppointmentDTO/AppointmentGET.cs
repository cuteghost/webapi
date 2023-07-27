using Models.Domain;

namespace Models.DTO.AppointmentDTO
{
    public class AppointmentGET
    {
        public long Id { get; set; }    
        public DateTime Date { get; set; }
        public string AppointmentStatus { get; set; } = string.Empty;
        public Staff? Staff { get; set; }
        public Patient? Patient { get; set; }   
    }
}