using Microsoft.EntityFrameworkCore;
using Models.Domain;
using Repository.Interfaces.MaterialInterfaces;
using server.Database;

namespace Repository.Classes.MaterialsRepo
{
    public class MaterialsUpdate : IMaterialsUpdate
    {
        private readonly DentalDBContext dbContext;

        public MaterialsUpdate(DentalDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<long?> UpdateMaterial(Material material)
        {
            var exists = await dbContext.Materials.FirstOrDefaultAsync(x => x.Id == material.Id);
            if(exists != null)
            {
                dbContext.Update(material);
                await dbContext.SaveChangesAsync();
                return material.Id;
            }
            return null;
        }
    }
}