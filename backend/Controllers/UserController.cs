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

    [HttpGet("AllUsers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AllAsync(CancellationToken cancellationToken, [FromQuery] int start = 0, [FromQuery] int count = 10)
    {
        var all = await _dbContext.Users.Skip(start).Take(count).ToListAsync(cancellationToken);
        var dto = all.Select(User => new GetUserDTO
        {
            Id = User.User_id,
            Nickname = User.Nickname,
        }).ToArray();

        return Ok(dto);
    }

    [HttpPost("CreateUser")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDTO createUserDTO, CancellationToken cancellationToken)
    {
        // Manually create the User entity from DTO properties
        var user = new User
        {
            Name = createUserDTO.Name,
            Surname = createUserDTO.Surname,
            Nickname = createUserDTO.Nickname,
            Email = createUserDTO.Email,
        };

        var createdUser = await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Ok(createdUser.Entity.User_id);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetUserById([FromRoute] int id, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FindAsync(id, cancellationToken);
        if (user is null)
        {
            return NotFound(id);
        }
        GetUserDTO dto = new GetUserDTO
        {
            Id = user.User_id,
            Nickname = user.Nickname,
        };
        return Ok(dto);
    }

}
