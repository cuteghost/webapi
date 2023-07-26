using Repository.Interfaces.ExperienceInterfaces;
using server.Database;
using Models.Domain;

namespace Repository.Classes.ExperiencesRepo;
public class ExperiencesCreate : IExperiencesCreate
{
    private readonly DentalDBContext _dbContext;
	public ExperiencesCreate(DentalDBContext dbContext)
	{
		_dbContext = dbContext;
	}
    public async Task<long> CreateExperience(Experience newExperience)
	{
		await _dbContext.AddAsync(newExperience);
		await _dbContext.SaveChangesAsync();

		return newExperience.Id;
	}
}
