using Validations.Common.Validations;
using Validations.Interfaces.Invoices;
using Models.DTO.InvoiceDTO;
namespace Validations.Classes.Invoices;
public class InvoiceValidations : IInvoiceValidations
{
    private readonly IValidationsService _validationsService;
    public InvoiceValidations(IValidationsService validationsService)
    {
        _validationsService = validationsService;
    }
    public async Task<ValidationModel> ValidatePOST(InvoicePOST newInvoice)
    {
        return new ValidationModel{
            ResultOfValidations = true,
            ValidationMessage = "Works ! ! !",
            StatusCode = 200
        };
    }
    public async Task<ValidationModel> ValidatePATCH(InvoicePATCH newInvoice)
    {
        return new ValidationModel{
            ResultOfValidations = true,
            ValidationMessage = "Works ! ! !",
            StatusCode = 200
        };
    }
    public async Task<ValidationModel> ValidateDELETE(long adminId, long invoiceId)
    {
        return new ValidationModel{
            ResultOfValidations = true,
            ValidationMessage = "Works ! ! !",
            StatusCode = 200
        };
    }
}