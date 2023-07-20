using Repository.Interfaces.InvoicesInterfaces;
using Microsoft.EntityFrameworkCore;
using server.Database;

namespace Repository.Classes.InvoicesRepo;

public class InvoicesDelete : IInvoicesDelete
{
    private readonly DentalDBContext _dbContext;

    public InvoicesDelete(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> DeleteInvoice(long invoiceId)
    {
        var invoice = await _dbContext.Invoices.FirstAsync(i => i.Id == invoiceId);
        _dbContext.Remove(invoice);
        await _dbContext.SaveChangesAsync();
        return invoiceId;
    }
}