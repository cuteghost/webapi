using Microsoft.EntityFrameworkCore;
using Models.Domain;
using Models.DTO.UserDTO.Patient;
using Repository.Interfaces.Users.PatientsInterface;
using server.Database;

namespace Repository.Classes.Users.PatientsRepo;

public class PatientsRead : IPatientsRead
{
    private readonly DentalDBContext _dbContext;
    public PatientsRead(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<PatientGET>> ReadPatientAsync()
    {
        var query = from patients in _dbContext.Patients
                    join users in _dbContext.Users on patients.User equals users
                    select new
                    {
                        FirstName = users.FirstName,
                        Lastname = users.LastName
                    };
        List<PatientGET> patientsList = new();
        foreach (var row in query)
        {
            PatientGET staffMember = new()
            {
                FirstName = row.FirstName,
                LastName = row.Lastname
            };
            patientsList.Add(staffMember);
        }
        return await Task.FromResult(patientsList);
    }

    public async Task<PatientGET> ReadPatientByEmail(string email)
    {
        var query = await (from patients in _dbContext.Patients
                           join users in _dbContext.Users on patients.User equals users
                           where users.Email == email
                           select new
                           {
                               FirstName = users.FirstName,
                               Lastname = users.LastName,
                               BirthDate = users.BirthDate,
                               Gender = users.Gender,
                               Email = users.Email,
                               JMBG = users.JMBG,
                               Adress = patients.Adress,
                               Telephone = patients.Telephone
                           }).FirstOrDefaultAsync();
        PatientGET patient = new()
        {
            FirstName = query.FirstName,
            LastName = query.Lastname,
            birthDate = query.BirthDate,
            Gender = Convert.ToInt16(query.Gender),
            Email = query.Email,
            JMBG = query.JMBG,
            Adress = query.Adress,
            Telephone = query.Telephone
        };


        return patient;
    }

    public async Task<Patient> ReadPatientByEmail(string email, string _)
    {
        return await _dbContext.Patients.Include(s => s.User).Where(u => u.User.Email == email).AsNoTracking().FirstOrDefaultAsync();
    }
}
