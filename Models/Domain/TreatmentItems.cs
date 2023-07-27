using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Domain;
public class TreatmentItems
{
    [Key]
    public long Id { get; set; }
    public Treatment? Treatment { get; set; }
    public Material? Material { get; set; }

    public float RequiredAmount { get; set; } = 0;

    [Column(TypeName ="datetime")]
    public DateTime CreatedOn { get; set; } = DateTime.Today;
}
