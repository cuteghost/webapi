using Models.Domain;
using Repository.Interfaces.LocationInterfaces;
using server.Database;
using Microsoft.EntityFrameworkCore;


namespace Repository.Classes.LocationsRepo;

public class LocationDelete : ILocationDelete
{
    private readonly DentalDBContext _dbContext;
    public LocationDelete(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> DeleteLocation(long locationId)
    {
        var location = await _dbContext.Locations.FirstAsync(s => s.Id == locationId);
        _dbContext.Remove(location);

        await _dbContext.SaveChangesAsync();
        return locationId;
    }
}