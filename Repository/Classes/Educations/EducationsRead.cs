using Repository.Interfaces.EducationInterfaces;
using Microsoft.EntityFrameworkCore;
using server.Database;
using webapi.Models.Domain;

namespace Repository.Classes.EducationsRepo;
public class EducationsRead : IEducationsRead
{
    private readonly DentalDBContext _dbContext;
    public EducationsRead(DentalDBContext dBContext)
    {
        _dbContext = dBContext;
    }
    public async Task<List<Education>> GetAllEducations()
    {
        return await _dbContext.Educations.ToListAsync();
    }
    public async Task<Education> GetEducation(long educationId)
    {
        return await _dbContext.Educations.FirstOrDefaultAsync(s => s.Id == educationId);
    }
}
