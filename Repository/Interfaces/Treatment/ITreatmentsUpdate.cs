using Models.Domain;

namespace Repository.Interfaces.TreatmentInterfaces
{
    public interface ITreatmentsUpdate
    {
        public Task<long?> UpdateTreatment(Treatment treatment, long treatmentId);
        public Task<long> UpdateTreatmentInvoice(long treatmentId, long invoiceId);
    }
}