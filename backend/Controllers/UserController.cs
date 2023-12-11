using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IMapper _mapper;

    public UserController(ILogger<UserController> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IActionResult> AllAsync(CancellationToken cancellationToken){
        return Ok();
    }
    public async Task<IActionResult> GetUserById(CancellationToken cancellationToken, int id){
        return Ok();
    }

}
