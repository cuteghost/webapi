namespace Models.DTO.TreatmentDTO
{
    public class TreatmentPATCH
    {        
        public string Diagnosis { get; set; } = string.Empty;

        public string DiagnosisCode { get; set; } = string.Empty;
        
        public DateTime TreatmentDate { get; set; } = DateTime.Now;
        public long AppointmentId { get; set; }
    }
}