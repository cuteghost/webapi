using Models.Domain;
using Repository.Interfaces.LocationInterfaces;
using server.Database;

namespace Repository.Classes.LocationsRepo;

public class LocationCreate : ILocationCreate
{
    private readonly DentalDBContext _dbContext;
    public LocationCreate(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<long> CreateLocation(Location newLocation)
    {
        await _dbContext.AddAsync(newLocation);
        await _dbContext.SaveChangesAsync();

        return newLocation.Id;
    }
}