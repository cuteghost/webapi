using Models.Domain;
using Repository.Interfaces.CountryInterfaces;
using server.Database;

namespace Repository.Classes.CountriesRepo;

public class CountryCreate : ICountryCreate
{
    private readonly DentalDBContext _dbContext;
    public CountryCreate(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<long> CreateCountry(Country newCountry)
    {
        await _dbContext.AddAsync(newCountry);
        await _dbContext.SaveChangesAsync();

        return newCountry.Id;
    }
}