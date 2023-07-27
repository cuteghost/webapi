using Models.Domain;

namespace Repository.Interfaces.CityInterfaces;

public interface ICityDelete
{
    public Task<long> DeleteCity(long cityId);
    
}