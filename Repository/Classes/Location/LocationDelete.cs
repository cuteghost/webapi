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

    public async Task<long> DeleteLocation(long Id)
    {
        var location = await _dbContext.Locations.FirstAsync(s => s.Id == Id);
        _dbContext.Remove(location);

        await _dbContext.SaveChangesAsync();
        return Id;
    }
}