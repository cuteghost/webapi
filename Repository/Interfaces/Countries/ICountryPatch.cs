using Models.Domain;

namespace Repository.Interfaces.CountryInterfaces;

public interface ICountryPatch
{
    public Task<long> PatchCountry(Country country);
}