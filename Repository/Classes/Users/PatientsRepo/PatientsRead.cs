using Dental_App.Models.DTO.UserDTO.Patient;
using Dental_App.Repository.Interfaces.Users.PatientsInterface;
using server.Database;

namespace Dental_App.Repository.Classes.Users.PatientsRepo;

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
        List<PatientGET> staffMembers = new();
        foreach (var row in query)
        {
            PatientGET staffMember = new()
            {
                FirstName = row.FirstName,
                LastName = row.Lastname
            };
            staffMembers.Add(staffMember);
        }
        return await Task.FromResult(staffMembers);
    }
}
