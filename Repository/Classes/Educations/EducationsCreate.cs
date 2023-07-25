using Repository.Interfaces.EducationInterfaces;
using server.Database;
using Models.Domain;

namespace Repository.Classes.EducationsRepo;
public class EducationsCreate : IEducationsCreate
{
    private readonly DentalDBContext _dbContext;
	public EducationsCreate(DentalDBContext dbContext)
	{
		_dbContext = dbContext;
	}
    public async Task<long> CreateEducation(Education newEducation)
	{
		await _dbContext.AddAsync(newEducation);
		await _dbContext.SaveChangesAsync();

		return newEducation.Id;
	}
}
