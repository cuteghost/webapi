namespace Models.DTO.TreatmentItemsDTO
{
    public class TreatmentItemsGET
    {
        public long TreatmentID { get; set; }
        public string MaterialName { get; set; } = string.Empty;
        public float RequiredAmount { get; set; } = 0;
    }
}