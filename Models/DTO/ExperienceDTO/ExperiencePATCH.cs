using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DTO.ExperienceDTO;
public class ExperiencePatch
{
    public long Id { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    [MaxLength(50)]
    [MinLength(3)]
    public string Title { get; set; } = string.Empty;
    [Column(TypeName = "nvarchar(50)")]
    [MaxLength(50)]
    [MinLength(3)]
    public string WorkPlace { get; set; } = string.Empty;
    [Column(TypeName = "datetime")]
    public DateTime From { get; set; } = DateTime.Now;
    [Column(TypeName = "datetime")]
    public DateTime To { get; set; } = DateTime.Now;
    public Location? Location { get; set; }
    public Staff? Staff { get; set; }

}
