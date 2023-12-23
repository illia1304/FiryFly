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
        var dto = all.Select(user =>
        {
            return new GetUserDTO
            {
                Id = user.User_id,
                Nickname = user.Nickname,
               // FollowersCount = user.Followers_count
            };
        }).ToArray();

        return Ok(dto);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById([FromRoute] int id, CancellationToken cancellationToken){
        var user = await _dbContext.Users.FindAsync(id, cancellationToken);
        if(user is null){
            return NotFound(id);
        }
        GetUserDTO dto = new GetUserDTO
        {
            Id = user.User_id,
            Nickname = user.Nickname,
            //FollowersCount = user.Followers_count
        };
        return Ok(dto);
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDTO createUserDTO, CancellationToken cancellationToken)
    {
        // Відобразити властивості з CreateUserDTO на об'єкт User
        var user = new User
        {
            Name = createUserDTO.Name,
            Email = createUserDTO.Email,
            Surname = createUserDTO.Surname,
            Nickname = createUserDTO.Nickname
        };

        // Додати об'єкт User до бази даних
        _dbContext.Users.Add(user); // Використовуйте Add, а не AddAsync тут
        await _dbContext.SaveChangesAsync();

        return Ok(user);
    }

}
