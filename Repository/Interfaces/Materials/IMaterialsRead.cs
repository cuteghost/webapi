using Models.Domain;

namespace Repository.Interfaces.MaterialInterfaces
{
    public interface IMaterialsRead
    {
        public Task<List<Material>> GetAllMaterials();
        public Task<Material> GetMaterialById(long materialId);
        public Task<bool> MaterialExists(long materialId);


    }
}