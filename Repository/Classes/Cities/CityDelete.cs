using Models.Domain;
using Repository.Interfaces.CityInterfaces;
using server.Database;
using Microsoft.EntityFrameworkCore;


namespace Repository.Classes.CitiesRepo;

public class CityDelete : ICityDelete
{
    private readonly DentalDBContext _dbContext;
    public CityDelete(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> DeleteCity(long Id)
    {
        var city = await _dbContext.Cities.FirstAsync(s => s.Id == Id);
        _dbContext.Remove(city);

        await _dbContext.SaveChangesAsync();
        return Id;
    }
}