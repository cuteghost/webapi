using Models.Domain;
using Repository.Interfaces.InvoicesInterfaces;
using server.Database;

namespace Repository.Classes.InvoicesRepo;
public class InvoicesUpdate : IInvoicesUpdate
{
    private readonly DentalDBContext _dbContext;
    public InvoicesUpdate(DentalDBContext dBContext)
    {
        _dbContext = dBContext; 
    }
    public async Task<long> UpdateInvoice(Invoice invoice)
    {
        _dbContext.Update(invoice);
        await _dbContext.SaveChangesAsync();
        return invoice.Id;
    }
}
