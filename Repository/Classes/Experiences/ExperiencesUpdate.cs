using Repository.Interfaces.ExperienceInterfaces;
using server.Database;
using Models.Domain;

namespace Repository.Classes.ExperiencesRepo;
public class ExperiencesUpdate : IExperiencesUpdate
{
    private readonly DentalDBContext _dbContext;
    public ExperiencesUpdate(DentalDBContext dBContext)
    {
        _dbContext = dBContext; 
    }
    public async Task<long> UpdateExperience(Experience experience)
    {
        _dbContext.Update(experience);
        await _dbContext.SaveChangesAsync();
        return experience.Id;
    }
}
