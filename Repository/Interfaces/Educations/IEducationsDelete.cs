namespace Repository.Interfaces.EducationInterfaces;

public interface IEducationsDelete
{
    public Task<long> DeleteEducation(long educationId);

}
