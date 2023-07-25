using Models.Domain;

namespace Repository.Interfaces.LocationInterfaces;

public interface ILocationCreate
{
    public Task<long> CreateLocation(Location newLocation);
}

