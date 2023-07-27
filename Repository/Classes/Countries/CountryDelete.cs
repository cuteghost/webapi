using Models.Domain;
using Repository.Interfaces.CountryInterfaces;
using server.Database;
using Microsoft.EntityFrameworkCore;


namespace Repository.Classes.CountriesRepo;

public class CountryDelete : ICountryDelete
{
    private readonly DentalDBContext _dbContext;
    public CountryDelete(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> DeleteCountry(long Id)
    {
        var country = await _dbContext.Countries.FirstAsync(s => s.Id == Id);
        _dbContext.Remove(country);

        await _dbContext.SaveChangesAsync();
        return Id;
    }
}