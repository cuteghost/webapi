using Models.Domain;
using Repository.Interfaces.TreatmentItems;
using server.Database;

namespace Repository.Classes.TreatmentItems;
public class TreatmentItemsCreate : ITreatmentItemsCreate
{

    private readonly DentalDBContext _dbContext;

    public TreatmentItemsCreate(DentalDBContext _dbContext)
    {
        this._dbContext = _dbContext;
    }
    public async Task<long> CreateTreatmentItem(Models.Domain.TreatmentItems newTreatmentItem)
    {
        await _dbContext.AddAsync(newTreatmentItem);
        await _dbContext.SaveChangesAsync();
        return newTreatmentItem.Id;
    }
}
