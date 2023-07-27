using Models.Domain;
using Repository.Interfaces.CityInterfaces;
using server.Database;
using Microsoft.EntityFrameworkCore;


namespace Repository.Classes.CitiesRepo;

public class CityRead : ICityRead
{
    private readonly DentalDBContext _dbContext;
    public CityRead(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<City>> GetAllCities()
    {
        var locations = await _dbContext.Cities.AsNoTracking().ToListAsync();
        return  locations;
    }

    public Task<City> GetCity()
    {
        throw new NotImplementedException();
    }
}