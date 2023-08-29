namespace Models.DTO.TreatmentDTO
{
    public class TreatmentPOST
    {        
        public string Diagnosis { get; set; } = string.Empty;
        public float Price { get; set; } = 0;
        public string DiagnosisCode { get; set; } = string.Empty;
        
        public DateTime TreatmentDate { get; set; } = DateTime.Now;
        public long AppointmentId { get; set; }
    }
}