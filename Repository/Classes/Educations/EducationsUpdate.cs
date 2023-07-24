using Repository.Interfaces.EducationInterfaces;
using server.Database;
using webapi.Models.Domain;

namespace Repository.Classes.EducationsRepo;
public class EducationsUpdate : IEducationsUpdate
{
    private readonly DentalDBContext _dbContext;
    public EducationsUpdate(DentalDBContext dBContext)
    {
        _dbContext = dBContext; 
    }
    public async Task<long> UpdateEducation(Education education)
    {
        _dbContext.Update(education);
        await _dbContext.SaveChangesAsync();
        return education.Id;
    }
}
