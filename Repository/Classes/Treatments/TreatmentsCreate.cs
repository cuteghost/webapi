using Models.Domain;
using Repository.Interfaces.TreatmentInterfaces;
using server.Database;

namespace Repository.Classes.TreatmentsRepo
{
    class TreatmentsCreate : ITreatmentsCreate
    {
        private readonly DentalDBContext dbContext;

        public TreatmentsCreate(DentalDBContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<long> CreateTreatment(Treatment newTreatment)
        {
            await dbContext.Treatments.AddAsync(newTreatment);
            await dbContext.SaveChangesAsync();

            return newTreatment.Id;
        }
    }
}