using Models.Domain;
using Repository.Interfaces.InvoicesInterfaces;
using Microsoft.EntityFrameworkCore;
using server.Database;

namespace Repository.Classes.InvoicesRepo;

public class InvoicesRead : IInvoicesRead
{
    private readonly DentalDBContext _dbContext;

    public InvoicesRead(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Invoice>> GetAllInvoices()
    {
        var invoiceTitles = await _dbContext.Invoices.AsNoTracking().ToListAsync();
        return invoiceTitles;
    }
    public async Task<Invoice> GetInvoiceDetails(long invoiceId)
    {
        var invoiceTitle = await _dbContext.Invoices.AsNoTracking().FirstAsync(i => i.Id == invoiceId);
        return invoiceTitle;
    }
    public async Task<long> InvoiceExists(long invoiceId)
    {
        var id = await _dbContext.Invoices.AsNoTracking().Where(i => i.Id == invoiceId).Select(i => i.Id).FirstAsync();
        return id;
    }

}