using Microsoft.EntityFrameworkCore;
using server.Database;
using Repository.Interfaces.EducationInterfaces;

namespace Repository.Classes.EducationsRepo;
public class EducationsDelete : IEducationsDelete
{
    private readonly DentalDBContext _dbContext;
    public EducationsDelete(DentalDBContext dBContext)
    {
        _dbContext = dBContext;
    }
    public async Task<long> DeleteEducation(long educationId)
    {
        var education = await _dbContext.Educations.FirstAsync(s => s.Id == educationId);
        _dbContext.Remove(education);
        await _dbContext.SaveChangesAsync();
        return educationId;
    }
}
