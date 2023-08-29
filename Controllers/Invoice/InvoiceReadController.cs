using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTO.InvoiceDTO;

namespace Controllers.InvoiceControllers;

public partial class InvoiceController : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var invoices = await _invoiceRead.GetAllInvoices();
        var toReturn = _mapper.Map<List<InvoiceGET>>(invoices);
        foreach (var i in toReturn)
        {
            i.StaffName = invoices.FirstOrDefault(x => x.Id == i.Id).Staff.User.FirstName + " " + invoices.FirstOrDefault(x => x.Id == i.Id).Staff.User.LastName;  
            i.PatientName = invoices.FirstOrDefault(x => x.Id == i.Id).Patient.User.FirstName + " " + invoices.FirstOrDefault(x => x.Id == i.Id).Patient.User.LastName;  

        }
        return Ok(toReturn);
    }
    [HttpGet]
    [Route("{id:long}")]
    public  async Task<IActionResult> GetById([FromRoute] long id)
    {
        var invoice = await _invoiceRead.GetInvoice(id);
        var toReturn = _mapper.Map<InvoiceGET>(invoice);
        toReturn.StaffName = invoice.Staff.User.FirstName + " " + invoice.Staff.User.LastName;
        toReturn.PatientName = invoice.Patient.User.FirstName + " " + invoice.Patient.User.LastName;
        return Ok(toReturn);
    }

}