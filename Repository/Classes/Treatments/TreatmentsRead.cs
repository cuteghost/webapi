using Models.Domain;
using server.Database;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.TreatmentInterfaces;

namespace Repository.Classes.TreatmentsRepo
{
    public class TreatmentsRead : ITreatmentsRead
    {
        private readonly DentalDBContext dbContext;

        public TreatmentsRead(DentalDBContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<List<Treatment>> GetAllTreatments()
        {
            var treatments = await dbContext.Treatments.AsNoTracking().ToListAsync();
            return treatments;
        }

        public async Task<Treatment?> GetTreatment(long TreatmentId)
        {
            return await dbContext.Treatments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == TreatmentId);
        }

        public async Task<bool> TreatmentExists(long treatmentId)
        {
            return await dbContext.Treatments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == treatmentId) != null ?  true :  false;
        }
    }
}