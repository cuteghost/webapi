using Models.Domain;

namespace Repository.Interfaces.LocationInterfaces;

public interface ILocationRead
{
    public Task<List<Location>> GetAllLocations();
    public Task<Location> GetLocation();

}