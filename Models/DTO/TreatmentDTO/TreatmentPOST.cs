namespace Models.DTO.TreatmentDTO
{
    public class TreatmentPOST
    {        
        public string Diagnosis { get; set; } = string.Empty;

        public string DiagnosisCode { get; set; } = string.Empty;
        
        public DateTime TreatmentDate { get; set; } = DateTime.Now;
    }
}