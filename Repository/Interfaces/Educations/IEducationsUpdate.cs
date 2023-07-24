using webapi.Models.Domain;

namespace Repository.Interfaces.EducationInterfaces;

public interface IEducationsUpdate
{
    public Task<long> UpdateEducation(Education education);
}
