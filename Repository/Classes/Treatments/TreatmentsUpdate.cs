using Microsoft.EntityFrameworkCore;
using Models.Domain;
using Repository.Interfaces.TreatmentInterfaces;
using server.Database;

namespace Repository.Classes.TreatmentsRepo
{
    public class TreatmentsUpdate : ITreatmentsUpdate
    {
        private readonly DentalDBContext dbContext;

        public TreatmentsUpdate(DentalDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<long?> UpdateTreatment(Treatment treatment, long treatmentId)
        {
            var exists = await dbContext.Treatments.FirstOrDefaultAsync(x => x.Id == treatmentId);
            if(exists != null)
            {
                dbContext.Update(treatment);
                await dbContext.SaveChangesAsync();
                return treatment.Id;
            }
            return null;
        }

        public async Task<long> UpdateTreatmentInvoice(long treatmentId, long invoiceId)
        {
            var exists = await dbContext.Treatments.FindAsync(treatmentId);
            if (exists != null)
            {
                exists.InvoiceId = invoiceId;
                await dbContext.SaveChangesAsync();
                return treatmentId;
            }
            else
            {
                return -1;
            }
        }
    }
}