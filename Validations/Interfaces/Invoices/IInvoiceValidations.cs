using Validations.Common.Validations;
using Validations.Interfaces.Invoices;
using Models.DTO.InvoiceDTO;
namespace Validations.Interfaces.Invoices;
public interface IInvoiceValidations
{
    public Task<ValidationModel> ValidatePOST(InvoicePOST newInvoice);
    public Task<ValidationModel> ValidatePATCH(InvoicePATCH newInvoice);
    public Task<ValidationModel> ValidateDELETE(long adminId, long invoiceId);
}