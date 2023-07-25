using Models.Domain;
using Repository.Interfaces.LocationInterfaces;
using server.Database;

namespace Repository.Classes.LocationsRepo;

public class LocationPatch : ILocationPatch
{
    private readonly DentalDBContext _dbContext;
    public LocationPatch(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> PatchLocation(Location location)
    {
        _dbContext.Update(location);
        await _dbContext.SaveChangesAsync();
        return location.Id;
    }
}