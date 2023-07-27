namespace Models.DTO.LocationDTO;
using Models.Domain;
public class LocationGet
{
    public long LocationId { get; set; }
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;

}
