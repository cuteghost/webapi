using Models.Domain;
using Repository.Interfaces.CityInterfaces;
using server.Database;

namespace Repository.Classes.CitiesRepo;

public class CityCreate : ICityCreate
{
    private readonly DentalDBContext _dbContext;
    public CityCreate(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<long> CreateCity(City newCity)
    {
        await _dbContext.AddAsync(newCity);
        await _dbContext.SaveChangesAsync();

        return newCity.Id;
    }
}