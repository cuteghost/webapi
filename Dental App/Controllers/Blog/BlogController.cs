using AutoMapper;
using Dental_App.Repository.Interfaces.BlogsInterfaces;
using Dental_App.Validations.Interfaces.Blogs;
using Microsoft.AspNetCore.Mvc;

namespace Dental_App.Controllers.Users.BlogControllers;
[ApiController]
[Route("/api/[controller]")]

public partial class BlogController : Controller
{
    private readonly IBlogValidations _blogValidations;
    private readonly IMapper _mapper;
    private readonly IBlogsCreate _blogCreate;
    private readonly IBlogsRead _blogRead;
    private readonly IBlogsUpdate _blogUpdate;
    private readonly IBlogsDelete _blogDelete;
    public BlogController(IBlogValidations blogValidations, IMapper mapper, IBlogsCreate blogCreate, IBlogsRead blogRead, IBlogsUpdate blogUpdate, IBlogsDelete blogDelete)
    {
        _blogValidations = blogValidations;
        _mapper = mapper;
        _blogCreate = blogCreate;
        _blogRead = blogRead;
        _blogUpdate = blogUpdate;
        _blogDelete = blogDelete;
    }
}
