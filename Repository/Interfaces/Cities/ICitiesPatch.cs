using Models.Domain;

namespace Repository.Interfaces.CityInterfaces;

public interface ICityPatch
{
    public Task<long> PatchCity(City city);
}