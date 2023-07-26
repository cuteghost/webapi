using Models.Domain;

namespace Repository.Interfaces.ExperienceInterfaces;

public interface IExperiencesUpdate
{
    public Task<long> UpdateExperience(Experience Experience);
}
