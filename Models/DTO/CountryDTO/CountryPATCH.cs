using System.ComponentModel.DataAnnotations;
using Models.Domain;
namespace Models.DTO.CountryDTO;
public class CountryPATCH
{
    public long CountryId { get; set; }
    [MaxLength(50)]
    [MinLength(5)]
    public string Name { get; set; } = string.Empty;

}
