using Models.Domain;
using Repository.Interfaces.CountryInterfaces;
using server.Database;

namespace Repository.Classes.CountriesRepo;

public class CountryPatch : ICountryPatch
{
    private readonly DentalDBContext _dbContext;
    public CountryPatch(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> PatchCountry(Country country)
    {
        _dbContext.Update(country);
        await _dbContext.SaveChangesAsync();
        return country.Id;
    }
}