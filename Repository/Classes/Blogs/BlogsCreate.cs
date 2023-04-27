using Models.Domain;
using Repository.Interfaces.BlogsInterfaces;
using server.Database;

namespace Repository.Classes.BlogsRepo;
public class BlogsCreate : IBlogsCreate
{
    private readonly DentalDBContext _dbContext;
	public BlogsCreate(DentalDBContext dbContext)
	{
		_dbContext = dbContext;
	}
    public async Task<long> CreateBlog(Blog newBlog)
	{
		await _dbContext.AddAsync(newBlog);
		await _dbContext.SaveChangesAsync();

		return newBlog.Id;
	}
}
