using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.TreatmentInterfaces;
using server.Database;

namespace Repository.Classes.TreatmentsRepo
{
    public class TreatmentsDelete : ITreatmentsDelete
    {
        private readonly DentalDBContext dbContext;

        public TreatmentsDelete(DentalDBContext _dbContext)
        {
            dbContext = _dbContext;     
        }
        public async Task<long?> DeleteTreatment(long treatmentId)
        {
            var treatment = await dbContext.Treatments.FirstOrDefaultAsync(x => x.Id == treatmentId);
            if(treatment != null)
            {
                dbContext.Remove(treatment);
                await dbContext.SaveChangesAsync();
                return treatmentId;
            }
            return null;
        }
    }
}