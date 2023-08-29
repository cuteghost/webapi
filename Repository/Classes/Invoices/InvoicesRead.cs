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
        var invoiceTitles = await _dbContext.Invoices.Include(p => p.Patient).Include(p => p.Patient.User)
                                                     .Include(s => s.Staff).Include(s => s.Staff.User)
                                                     .AsNoTracking().ToListAsync();
        return invoiceTitles;
    }
    public async Task<Invoice> GetInvoice(long invoiceId)
    {
        var invoiceTitle = await _dbContext.Invoices.Include(p => p.Patient).Include(p => p.Patient.User)
                                                     .Include(s => s.Staff).Include(s => s.Staff.User)
                                                     .AsNoTracking().FirstAsync(i => i.Id == invoiceId);
        return invoiceTitle;
    }
}