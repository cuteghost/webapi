namespace Repository.Interfaces.InvoicesInterfaces;

public interface IInvoicesDelete
{
    public Task<long> DeleteInvoice(long invoiceId);

}
