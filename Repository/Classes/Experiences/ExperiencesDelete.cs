using Microsoft.EntityFrameworkCore;
using server.Database;
using Repository.Interfaces.ExperienceInterfaces;

namespace Repository.Classes.ExperiencesRepo;
public class ExperiencesDelete : IExperiencesDelete
{
    private readonly DentalDBContext _dbContext;
    public ExperiencesDelete(DentalDBContext dBContext)
    {
        _dbContext = dBContext;
    }
    public async Task<long> DeleteExperience(long experienceId)
    {
        var experience = await _dbContext.Experiences.FirstAsync(s => s.Id == experienceId);
        _dbContext.Remove(experience);
        await _dbContext.SaveChangesAsync();
        return experienceId;
    }
}
