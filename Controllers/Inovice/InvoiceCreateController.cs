using Models.Domain;
using Models.DTO.InvoiceDTO;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Users.InvoiceControllers;

public partial class InvoiceController : Controller
{
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateInvoiceAsync(InvoicePOST newInvoiceDTO)
    {
        var validationResult = await _invoiceValidations.ValidatePOST(newInvoiceDTO);
        if(validationResult.ResultOfValidations == true)
        {
            var newInvoice = _mapper.Map<Invoice>(newInvoiceDTO);
            await _invoiceCreate.CreateInvoice(newInvoice);
        }
        return await _responseService.Response(validationResult.StatusCode,validationResult.ValidationMessage);

    }
}