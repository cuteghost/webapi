using Models.Domain;

namespace Repository.Interfaces.LocationInterfaces;

public interface ILocationPatch
{
    public Task<long> PatchLocation(Location location);
}