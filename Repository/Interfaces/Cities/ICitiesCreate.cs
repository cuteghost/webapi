using Models.Domain;

namespace Repository.Interfaces.CityInterfaces;

public interface ICityCreate
{
    public Task<long> CreateCity(City newCity);
}

