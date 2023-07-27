namespace Models.DTO.CityDTO;
using Models.Domain;
public class CityGET
{
    public long CityId { get; set; }
    public string Name { get; set; }
    public string Country { get; set; } = string.Empty;

}
