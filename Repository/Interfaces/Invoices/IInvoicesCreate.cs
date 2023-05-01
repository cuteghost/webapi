using Models.Domain;

namespace Repository.Interfaces.InvoicesInterfaces;

public interface IInvoicesCreate
{
    public Task<long> CreateInvoice(Invoice newInvoice);
}
