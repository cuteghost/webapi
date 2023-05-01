using AutoMapper;
using Repository.Interfaces.InvoicesInterfaces;
using Validations.Interfaces.Invoices;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;

namespace Controllers.Users.InvoiceControllers;
[ApiController]
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
    public InvoiceController(IInvoiceValidations invoiceValidations, IMapper mapper, IInvoicesCreate invoiceCreate, IInvoicesRead invoiceRead, IInvoicesUpdate invoiceUpdate, IResponseService responseService, IInvoicesDelete invoiceDelete)
    {
        _invoiceValidations = invoiceValidations;
        _invoiceCreate = invoiceCreate;
        _invoiceRead = invoiceRead;
        _invoiceUpdate = invoiceUpdate;
        _invoiceDelete = invoiceDelete;
        _mapper = mapper;
        _responseService = responseService;
    }
}
