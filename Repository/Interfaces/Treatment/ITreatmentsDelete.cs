namespace Repository.Interfaces.TreatmentInterfaces
{
    public interface ITreatmentsDelete
    {
        public Task<long?> DeleteTreatment(long treatmentId);
    }
}