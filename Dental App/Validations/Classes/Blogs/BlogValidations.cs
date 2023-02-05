using Dental_App.Models.DTO.BlogDTO;
using Dental_App.Validations.Interfaces.Blogs;
using Microsoft.EntityFrameworkCore;
using server.Database;

namespace Dental_App.Validations.Classes.Blogs;
public class BlogValidations : IBlogValidations
{
    private readonly DentalDBContext _dbContext;
    public Common.Validations validations { get; set; }
    public BlogValidations(DentalDBContext dbContext, Common.Validations validations)
    {
        _dbContext = dbContext;
        this.validations = validations;
    }
    //TODO: Dodati poruke ukoliko validacije ne prodju na svim metodama.
    public async Task<bool> ValidatePOST(BlogPOST newBlog)
    {
        if(validations.ValidateLength(newBlog.Content,200,4000) == false)
        {
            return false;
        }
        if (validations.ValidateLength(newBlog.Title, 10, 50) == false)
        {
            return false;
        }

        if(await ValidateCreator(newBlog.CreatorId) == false)
        {
            return false;
        }
        return true;
    }
    public async Task<bool> ValidatePATCH(BlogPatch blog)
    {
        if (validations.ValidateLength(blog.Content, 200, 4000) == false)
        {
            return false;
        }
        if (validations.ValidateLength(blog.Title, 10, 50) == false)
        {
            return false;
        }

        if (await ValidateCreator(blog.Id,blog.CreatorId) == false)
        {
            return false;
        }
        return true;
    }
    public async Task<bool> ValidateDELETE(long blogId, long creatorId)
    {
        if (await ValidateCreator(blogId, creatorId) == false)
        {
            return false;
        }
        return true;
    }
    public async Task<bool> ValidateCreator(long creatorId)
    {
        if(creatorId == 0)
        {
            return false;
        }
        if (await _dbContext.Staff.AsNoTracking().FirstOrDefaultAsync(s=> s.User.Id == creatorId) == null)
        {
            return false;
        }
        return true;
    }
    public async Task<bool> ValidateCreator(long blogId, long creatorId)
    {
        if(blogId == 0)
        {
            return false;
        }
        if (creatorId == 0)
        {
            return false;
        }
        if (await _dbContext.Blogs.AsNoTracking().Where(blogs=> blogs.Id == blogId && blogs.Creator.Id == creatorId).FirstOrDefaultAsync() == null)
        {
            return false;
        }
        return true;
    }
}
