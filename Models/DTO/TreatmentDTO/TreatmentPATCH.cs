namespace Models.DTO.TreatmentDTO
{
    public class TreatmentPATCH
    {        
        public string Diagnosis { get; set; } = string.Empty;

        public string DiagnosisCode { get; set; } = string.Empty;
        
        public DateTime TreatmentDate { get; set; } = DateTime.Now;
        //citaj komentar na patch requestu vezano za polja: 
        //StaffId i PatientId
        public long StaffId { get; set; }
        public long PatientId { get; set; }

    }
}