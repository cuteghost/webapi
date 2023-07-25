using Models.Domain;

namespace Repository.Interfaces.EducationInterfaces;

public interface IEducationsCreate
{
    public Task<long> CreateEducation(Education newEducation);
}
