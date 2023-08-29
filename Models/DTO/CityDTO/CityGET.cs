namespace Models.DTO.CityDTO;
using Models.Domain;
public class CityGET
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string CountryName { get; set; } = string.Empty;

}
