using System.ComponentModel.DataAnnotations;
using Models.Domain;
namespace Models.DTO.LocationDTO;
public class LocationPatch
{
    public long LocationId { get; set; }
    [MaxLength(50)]
    [MinLength(5)]
    public string Address { get; set; } = string.Empty;
    public long CityId { get; set; }

}
