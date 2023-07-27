using System.ComponentModel.DataAnnotations;
using Models.Domain;
namespace Models.DTO.CityDTO;
public class CityPATCH
{
    public long CityId { get; set; }
    [MaxLength(50)]
    [MinLength(5)]
    public string Name { get; set; } = string.Empty;
    public long CountryId { get; set; }

}
