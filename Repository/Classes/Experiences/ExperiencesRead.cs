using Repository.Interfaces.ExperienceInterfaces;
using Microsoft.EntityFrameworkCore;
using server.Database;
using Models.Domain;

namespace Repository.Classes.ExperiencesRepo;
public class ExperiencesRead : IExperiencesRead
{
    private readonly DentalDBContext _dbContext;
    public ExperiencesRead(DentalDBContext dBContext)
    {
        _dbContext = dBContext;
    }
    public async Task<List<Experience>> GetAllExperiences()
    {
        return await _dbContext.Experiences.ToListAsync();
    }
    public async Task<Experience> GetExperience(long experienceId)
    {
        return await _dbContext.Experiences.FirstOrDefaultAsync(s => s.Id == experienceId);
    }
}
