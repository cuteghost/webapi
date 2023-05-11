using Models.Domain;

namespace Repository.Interfaces.TreatmentInterfaces
{
    public interface ITreatmentsCreate
    {
        public Task<long> CreateTreatment(Treatment newTreatment);
    }
}