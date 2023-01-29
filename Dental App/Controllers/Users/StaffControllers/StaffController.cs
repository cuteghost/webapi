using AutoMapper;
using Dental_App.Models.Domain;
using Dental_App.Models.DTO.UserDTO.Staff;
using Dental_App.Repository.Interfaces.Users.StaffInterfaces;
using Dental_App.Validations.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace Dental_App.Controllers.Users.StaffControllers;

[ApiController]
[Route("api/[controller]")]
public partial class StaffController : Controller
{
    private readonly IStaffCreate _staffCreateRepository;
    private readonly IStaffRead _staffReadRepository;
    private readonly IStaffUpdate _staffUpdateRepository;
    private readonly IStaffDelete _staffDeleteRepository;


    private readonly IStaffValidations _staffValidations;
    private readonly IMapper _mapper;

    public StaffController(IStaffCreate staffCreateRepository, IStaffRead staffReadRepository, IStaffUpdate staffUpdateRepository, IStaffDelete staffDeleteRepository, IStaffValidations staffValidations, IMapper mapper)
    {
        _staffCreateRepository = staffCreateRepository;
        _staffReadRepository = staffReadRepository;
        _staffUpdateRepository = staffUpdateRepository;
        _staffDeleteRepository = staffDeleteRepository;
        _staffValidations = staffValidations;
        _mapper = mapper;
    }
}
