using Models.Domain;

namespace Repository.Interfaces.CountryInterfaces;

public interface ICountryDelete
{
    public Task<long> DeleteCountry(long countryId);
    
}