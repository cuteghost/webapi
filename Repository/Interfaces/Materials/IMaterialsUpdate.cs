using Models.Domain;

namespace Repository.Interfaces.MaterialInterfaces
{
    public interface IMaterialsUpdate
    {
        public Task<long?> UpdateMaterial(Material newMaterial);
    }
}