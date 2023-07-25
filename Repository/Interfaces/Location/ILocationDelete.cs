using Models.Domain;

namespace Repository.Interfaces.LocationInterfaces;

public interface ILocationDelete
{
    public Task<long> DeleteLocation(long locationId);
    
}