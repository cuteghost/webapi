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

        if (validationResult.ResultOfValidations == true)
        {
            var newInvoice = _mapper.Map<Invoice>(newInvoiceDTO);

            /* 
                mozda bi ovdje trebalo postaviti neku validaciju i za pacijente i za staffove 
            */

            var staffMemberDto = await _staffRead.GetStaffMember(newInvoiceDTO.StaffId);
            newInvoice.Staff = _mapper.Map<Staff>(staffMemberDto);
           
            var patientDto = await _patientRead.ReadPatientById(newInvoiceDTO.StaffId);
            newInvoice.Patient = _mapper.Map<Patient>(patientDto);

            await _invoiceCreate.CreateInvoice(newInvoice);
        }

        return await _responseService.Response(validationResult.StatusCode,validationResult.ValidationMessage);

    }
}