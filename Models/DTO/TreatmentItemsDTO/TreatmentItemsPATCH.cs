namespace Models.DTO.TreatmentItemsDTO
{
    public class TreatmentItemsPATCH
    {
        public long Id { get; set; }
        public long TreatmentID { get; set; }
        public long MaterialId { get; set; }
        public float RequiredAmount { get; set; } = 0;

    }
}