using Models.Domain;

namespace Repository.Interfaces.ExperienceInterfaces;

public interface IExperiencesRead
{
    public Task<List<Experience>> GetAllExperiences();
    public Task<Experience> GetExperience(long ExperienceId);
}
