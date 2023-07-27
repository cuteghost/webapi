using Models.Domain;

namespace Repository.Interfaces.CountryInterfaces;

public interface ICountryRead
{
    public Task<List<Country>> GetAllCountries();
    public Task<Country> GetCountry();

}