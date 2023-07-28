namespace Models.DTO.TreatmentDTO
{
    public class TreatmentGET
    {
        public long Id { get; set; }
        
        public string Diagnosis { get; set; } = string.Empty;

        public string DiagnosisCode { get; set; } = string.Empty;
        
        public DateTime TreatmentDate { get; set; } = DateTime.Now;
        public string StaffName { get; set; } = string.Empty;
        public string StaffDetails { get; set; } = string.Empty;
    }
}