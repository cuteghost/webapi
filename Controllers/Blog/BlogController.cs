using AutoMapper;
using Repository.Interfaces.BlogsInterfaces;
using Validations.Interfaces.Blogs;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;

namespace Controllers.Users.BlogControllers;
[ApiController]
[Route("/api/[controller]")]

public partial class BlogController : Controller
{
    private readonly IBlogValidations _blogValidations;
    private readonly IMapper _mapper;
    private readonly IBlogsCreate _blogCreate;
    private readonly IBlogsRead _blogRead;
    private readonly IBlogsUpdate _blogUpdate;
    private readonly IResponseService _responseService;
    private readonly IBlogsDelete _blogDelete;
    public BlogController(IBlogValidations blogValidations, IMapper mapper, IBlogsCreate blogCreate, IBlogsRead blogRead, IBlogsUpdate blogUpdate, IResponseService responseService, IBlogsDelete blogDelete)
    {
        _blogValidations = blogValidations;
        _blogCreate = blogCreate;
        _blogRead = blogRead;
        _blogUpdate = blogUpdate;
        _blogDelete = blogDelete;
        _mapper = mapper;
        _responseService = responseService;
    }
}
