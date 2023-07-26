namespace Models.DTO.TreatmentDTO
{
    public class TreatmentPOST
    {        
        public string Diagnosis { get; set; } = string.Empty;

        public string DiagnosisCode { get; set; } = string.Empty;
        
        public DateTime TreatmentDate { get; set; } = DateTime.Now;
        //Ovdje ide long a ne Staff ili Patient tip objekta
        //zato sto ce se Domeni prosljedjivati staff koji se dobije
        //preko metode iz StaffRepozitorija
        //isto vazi za sve ostale slicne veze na requestovima
        public long StaffId { get; set; }
        public long PatientId { get; set; }
    }
}