using Models.Domain;
using Models.DTO.InvoiceDTO;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.InvoiceControllers;

public partial class InvoiceController : Controller
{
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateInvoiceAsync(InvoicePOST newInvoiceDTO)
    {
        var validationResult = await _invoiceValidations.ValidatePOST(newInvoiceDTO);
        long id = 0;
        if (validationResult.ResultOfValidations == true)
        {
            var newInvoice = _mapper.Map<Invoice>(newInvoiceDTO);

            var staffMember = await _staffRead.GetStaff(newInvoiceDTO.StaffId);
            newInvoice.Staff = staffMember;
           
            var patient = await _patientRead.ReadPatient(newInvoiceDTO.PatientId);
            newInvoice.Patient = patient;

            await _invoiceCreate.CreateInvoice(newInvoice);
            id = newInvoice.Id;
        }

        return await _responseService.Response(validationResult.StatusCode, id);

    }
}