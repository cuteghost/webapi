using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.MaterialInterfaces;
using server.Database;

namespace Repository.Classes.MaterialsRepo
{
    public class MaterialsDelete : IMaterialsDelete
    {
        private readonly DentalDBContext dbContext;

        public MaterialsDelete(DentalDBContext _dbContext)
        {
            dbContext = _dbContext;     
        }
        public async Task<long?> DeleteMaterial(long materialId)
        {
            var material = await dbContext.Materials.FirstOrDefaultAsync(x => x.Id == materialId);
            if(material != null)
            {
                dbContext.Remove(material);
                await dbContext.SaveChangesAsync();
                return materialId;
            }
            return null;
        }
    }
}