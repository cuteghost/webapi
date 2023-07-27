using Models.Domain;

namespace Repository.Interfaces.CityInterfaces;

public interface ICityRead
{
    public Task<List<City>> GetAllCities();
    public Task<City> GetCity();

}