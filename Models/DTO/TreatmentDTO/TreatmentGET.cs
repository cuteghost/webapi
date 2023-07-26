namespace Models.DTO.TreatmentDTO
{
    public class TreatmentGET
    {
        public long Id { get; set; }
        
        public string Diagnosis { get; set; } = string.Empty;

        public string DiagnosisCode { get; set; } = string.Empty;
        
        public DateTime TreatmentDate { get; set; } = DateTime.Now;
        public string StaffName { get; set; } = string.Empty;
        //ovo je opcionalni parametar StaffDetails u slucaju
        //da je potrebno pokupiti jos neku informaciju sa stafa
        public string StaffDetails { get; set; } = string.Empty;
        //isto vazi i za pacijenta kao i za stafa
        public string PatientName { get; set; } = string.Empty;
        public string PatientDetails { get; set; } = string.Empty;
    }
}