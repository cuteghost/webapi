using Models.Domain;
using Repository.Interfaces.CountryInterfaces;
using server.Database;
using Microsoft.EntityFrameworkCore;


namespace Repository.Classes.CountriesRepo;

public class CountryRead : ICountryRead
{
    private readonly DentalDBContext _dbContext;
    public CountryRead(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Country>> GetAllCountries()
    {
        var locations = await _dbContext.Countries.AsNoTracking().ToListAsync();
        return  locations;
    }

    public Task<Country> GetCountry()
    {
        throw new NotImplementedException();
    }
}