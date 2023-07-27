namespace Repository.Interfaces.TreatmentItems;
using Models.Domain;
public interface ITreatmentItemsCreate
{
    public Task<long> CreateTreatmentItem(TreatmentItems newTreatmentItem);
}
