using Models.Domain;

namespace Repository.Interfaces.TreatmentInterfaces
{
    public interface ITreatmentsRead
    {
        public Task<List<Treatment>> GetAllTreatments();
        public Task<Treatment?> GetTreatment(long TreatmentId);
        public Task<bool> TreatmentExists(long TreatmentId);
    }
}