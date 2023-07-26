namespace Repository.Interfaces.ExperienceInterfaces;

public interface IExperiencesDelete
{
    public Task<long> DeleteExperience(long ExperienceId);

}
