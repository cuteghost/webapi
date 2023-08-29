using Models.Domain;

namespace Repository.Interfaces.InvoicesInterfaces;

public interface IInvoicesRead
{
    public Task<List<Invoice>> GetAllInvoices();

    public Task<Invoice> GetInvoice(long invoiceId);

}