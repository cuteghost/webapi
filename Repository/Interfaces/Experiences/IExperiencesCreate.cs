using Models.Domain;

namespace Repository.Interfaces.ExperienceInterfaces;

public interface IExperiencesCreate
{
    public Task<long> CreateExperience(Experience newExperience);
}
