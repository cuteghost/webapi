using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models.DTO.EducationDTO;
public class EducationGet
{
    public string Title { get; set; } = string.Empty;
    public string School { get; set; } = string.Empty;
    public DateTime From { get; set; } = DateTime.Now;
    public DateTime To { get; set; } = DateTime.Now;
    public Location? Location { get; set; }
    public long StaffId { get; set; }
}
