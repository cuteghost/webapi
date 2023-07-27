namespace Repository.Classes.TreatmentItemsInterfaces;
using Models.Domain;
public interface ITreatmentItemsCreate
{
    public Task<long> CreateTreatmentItem(TreatmentItems newTreatmentItem);
}
