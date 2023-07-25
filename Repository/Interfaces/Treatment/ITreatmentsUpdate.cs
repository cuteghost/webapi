using Models.Domain;

namespace Repository.Interfaces.TreatmentInterfaces
{
    public interface ITreatmentsUpdate
    {
        public Task<long?> UpdateTreatment(Treatment treatment, long treatmentId);
    }
}