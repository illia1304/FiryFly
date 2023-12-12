using AutoMapper;
using backend.DataModels;
using backend.DTO.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IMapper _mapper;
    private readonly Dbcontext _dbContext;

    public UserController(ILogger<UserController> logger, IMapper mapper, Dbcontext dbcontext)
    {
        _logger = logger;
        _mapper = mapper;
        _dbContext = dbcontext;
    }

    [HttpGet("")]
    public async Task<IActionResult> AllAsync(CancellationToken cancellationToken, [FromQuery] int start = 0, [FromQuery] int count = 10){
        var all = await _dbContext.Users.Skip(start).Take(count).ToListAsync(cancellationToken);
        return Ok(all.Select(
            c=> _mapper.Map<User, GetUserDTO>(c)
        ).ToArray()
        );
    }
    public async Task<IActionResult> GetUserById([FromRoute] int id, CancellationToken cancellationToken){
        var user = _dbContext.Users.FindAsync(id, cancellationToken);
        if(user is null){
            return NotFound(id);
        }
        return Ok(_mapper.Map<User, GetUserDTO>(cancellationToken));
    }

}
