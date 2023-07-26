using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Domain
{
    public class Asset
    {
        [Key]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }

    }
}