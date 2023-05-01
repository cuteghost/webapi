using Models.Domain;

namespace Repository.Interfaces.InvoicesInterfaces;

public interface IInvoicesUpdate
{
    public Task<long> UpdateInvoice(Invoice invoice);
}