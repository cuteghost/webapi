using Models.Domain;
using server.Database;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.MaterialInterfaces;

namespace Repository.Classes.MaterialsRepo
{
    public class MaterialsRead : IMaterialsRead
    {
        private readonly DentalDBContext dbContext;

        public MaterialsRead(DentalDBContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<List<Material>> GetAllMaterials()
        {
            var materials = await dbContext.Materials.AsNoTracking().ToListAsync();
            return materials;
        }

        public async Task<Material?> GetMaterialById(long MaterialId)
        {
            return await dbContext.Materials.AsNoTracking().FirstOrDefaultAsync(x => x.Id == MaterialId);
        }

        public async Task<bool> MaterialExists(long materialId)
        {
            return await dbContext.Materials.AsNoTracking().FirstOrDefaultAsync(x => x.Id == materialId) != null ?  true :  false;
        }
    }
}