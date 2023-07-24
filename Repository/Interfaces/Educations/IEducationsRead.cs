using webapi.Models.Domain;

namespace Repository.Interfaces.EducationInterfaces;

public interface IEducationsRead
{
    public Task<List<Education>> GetAllEducations();
    public Task<Education> GetEducation(long educationId);
}
