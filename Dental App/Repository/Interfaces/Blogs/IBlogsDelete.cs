namespace Dental_App.Repository.Interfaces.BlogsInterfaces;

public interface IBlogsDelete
{
    public Task<long> DeleteBlog(long blogId);

}
