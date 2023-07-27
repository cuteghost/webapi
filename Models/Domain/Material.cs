using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Domain
{
    public class Material
    {
        [Key]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }    
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "bigint")]
        public long StockAmount { get; set; } 

    }
}