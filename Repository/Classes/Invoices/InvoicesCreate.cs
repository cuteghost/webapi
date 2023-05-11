using Models.Domain;
using Repository.Interfaces.InvoicesInterfaces;
using server.Database;

namespace Repository.Classes.InvoicesRepo;

public class InvoicesCreate : IInvoicesCreate
{
    private readonly DentalDBContext _dbContext;

    public InvoicesCreate(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> CreateInvoice(Invoice newInvoice)
    {
        await _dbContext.AddAsync(newInvoice);
        await _dbContext.SaveChangesAsync();

        return newInvoice.Id;
    }
}