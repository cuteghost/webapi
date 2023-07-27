namespace Models.DTO.MaterialDTO
{
    public class MaterialGET
    {
        public long Id { get; set; }    
        public string Name { get; set; } = string.Empty;
        public long StockAmount { get; set; }
    }
}