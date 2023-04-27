using Validations.Common.Validations;
using Validations.Interfaces.Invoices;

namespace Validations.Classes.Invoices;
public class InvoiceValidations : IInvoiceValidations
{
    private readonly IValidationsService _validationsService;
    public InvoiceValidations(IValidationsService validationsService)
    {
        _validationsService = validationsService;
    }
}