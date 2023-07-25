using AutoMapper;
using Repository.Interfaces.InvoicesInterfaces;
using Validations.Interfaces.Invoices;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;
using Microsoft.AspNetCore.Authorization;
using Repository.Interfaces.Users.StaffInterfaces;
using Repository.Interfaces.Users.PatientsInterface;

namespace Controllers.Users.InvoiceControllers;
[ApiController]
[Authorize]
[Route("/api/[controller]")]

public partial class InvoiceController : Controller
{
    private readonly IInvoiceValidations _invoiceValidations;
    private readonly IMapper _mapper;
    private readonly IInvoicesCreate _invoiceCreate;
    private readonly IInvoicesRead _invoiceRead;
    private readonly IInvoicesUpdate _invoiceUpdate;
    private readonly IInvoicesDelete _invoiceDelete;
    private readonly IResponseService _responseService;

    /* 
    Ovaj dio je ukljucen kako bi se dohvatili podaci za pacijenta i staffa preko repozitorija. 
    */
    private readonly IStaffRead _staffRead;
    private readonly IPatientsRead _patientRead;
    public InvoiceController(IInvoiceValidations invoiceValidations, 
        IMapper mapper, 
        IInvoicesCreate invoiceCreate, 
        IInvoicesRead invoiceRead, 
        IInvoicesUpdate invoiceUpdate, 
        IResponseService responseService, 
        IInvoicesDelete invoiceDelete,
        IStaffRead staffRead,
        IPatientsRead patientRead)
    {
        _invoiceValidations = invoiceValidations;
        _invoiceCreate = invoiceCreate;
        _invoiceRead = invoiceRead;
        _invoiceUpdate = invoiceUpdate;
        _invoiceDelete = invoiceDelete;
        _mapper = mapper;
        _responseService = responseService;
        _staffRead = staffRead;
        _patientRead = patientRead;
    }
}
