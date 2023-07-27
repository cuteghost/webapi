using Models.Domain;
using Repository.Interfaces.MaterialInterfaces;
using server.Database;

namespace Repository.Classes.MaterialsRepo
{
    class MaterialsCreate : IMaterialsCreate
    {
        private readonly DentalDBContext dbContext;

        public MaterialsCreate(DentalDBContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<long> CreateMaterial(Material newMaterial)
        {
            await dbContext.AddAsync(newMaterial);
            await dbContext.SaveChangesAsync();

            return newMaterial.Id;
        }
    }
}