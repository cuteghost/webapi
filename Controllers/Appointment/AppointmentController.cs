using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces.AppointmentInterfaces;
using Repository.Interfaces.Users.PatientsInterface;
using Repository.Interfaces.Users.StaffInterfaces;
using Services.ResponseService;

namespace Controllers.AppointmentControllers
{
    [ApiController]
    [Route("/api/[controller]")] 
    public partial class AppointmentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentsCreate _appointmentCreate;
        private readonly IAppointmentsRead _appointmentsRead;
        private readonly IAppointmentsDelete _appointmentsDelete;
        private readonly IAppointmentsUpdate _appointmentsUpdate;
        private readonly IResponseService _responseService;

        private readonly IStaffRead _staffRead;
        private readonly IPatientsRead _patientRead;

        public AppointmentController
        (
            IMapper mapper,
            IAppointmentsCreate appointmentCreate,
            IAppointmentsRead appointmentsRead,
            IAppointmentsDelete appointmentsDelete,
            IAppointmentsUpdate appointmentsUpdate,
            IResponseService responseService,
            IStaffRead staffRead,
            IPatientsRead patientRead
        )
        {
            _mapper = mapper;
            _appointmentCreate = appointmentCreate;
            _appointmentsRead = appointmentsRead;
            _appointmentsDelete = appointmentsDelete;
            _appointmentsUpdate = appointmentsUpdate;
            _responseService = responseService;
            _staffRead = staffRead;
            _patientRead = patientRead;
        }
    }
}