using Models.Domain;
using Repository.Interfaces.LocationInterfaces;
using server.Database;
using Microsoft.EntityFrameworkCore;


namespace Repository.Classes.LocationsRepo;

public class LocationRead : ILocationRead
{
    private readonly DentalDBContext _dbContext;
    public LocationRead(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Location>> GetAllLocations()
    {
        var locations = await _dbContext.Locations.AsNoTracking().ToListAsync();
        return  locations;
    }

    public Task<Location> GetLocation()
    {
        throw new NotImplementedException();
    }
}