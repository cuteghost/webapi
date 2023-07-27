using Models.Domain;

namespace Repository.Interfaces.MaterialInterfaces
{
    public interface IMaterialsCreate
    {
        public Task<long> CreateMaterial(Material newMaterial);
    }
}