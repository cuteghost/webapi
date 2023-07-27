using Models.Domain;
using Repository.Interfaces.CityInterfaces;
using server.Database;

namespace Repository.Classes.CitiesRepo;

public class CityPatch : ICityPatch
{
    private readonly DentalDBContext _dbContext;
    public CityPatch(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> PatchCity(City city)
    {
        _dbContext.Update(city);
        await _dbContext.SaveChangesAsync();
        return city.Id;
    }
}