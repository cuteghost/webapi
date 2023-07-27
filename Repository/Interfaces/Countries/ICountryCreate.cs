using Models.Domain;

namespace Repository.Interfaces.CountryInterfaces;

public interface ICountryCreate
{
    public Task<long> CreateCountry(Country newCountry);
}

