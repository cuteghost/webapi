using Models.Domain;
using Models.DTO.InvoiceDTO;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.InvoiceControllers;

public partial class InvoiceController : Controller
{
    [HttpDelete]
    [Route("{id:long}/delete")]
    public async Task<IActionResult> DeleteInvoiceAsync(long id)
    {
        try
        {
            var deleteInvoice = await _invoiceDelete.DeleteInvoice(id);
            return Ok(id);
        }
        catch (System.Exception)
        {
            return NotFound();
        }

    }
}