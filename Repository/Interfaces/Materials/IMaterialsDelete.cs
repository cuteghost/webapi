using Models.Domain;

namespace Repository.Interfaces.MaterialInterfaces
{
    public interface IMaterialsDelete
    {
        public Task<long?> DeleteMaterial(long materialId);
    }
}