using AutoMapper;
using backend.DataModels;
using backend.DTO.LongreadsDTO;
using backend.DTO.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class LongreadController : ControllerBase
{
    private readonly ILogger<LongreadController> _logger;
    private readonly IMapper _mapper;
    private readonly Dbcontext _dbContext;

    public LongreadController(ILogger<LongreadController> logger, IMapper mapper, Dbcontext dbcontext)
    {
        _logger = logger;
        _mapper = mapper;
        _dbContext = dbcontext;
    }
    
    [HttpPost("CreateLongread")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateLongread(CancellationToken cancellationToken, LongreadDTO longreadDTO)
    {
        int authorId = longreadDTO.AuthorId;
        User user = await _dbContext.Users.FirstOrDefaultAsync(x => x.User_id == authorId);
        if (user == null)
        {
            return NotFound();
        }
            
        var longread = new Longread
        {
            Title = longreadDTO.Title,
            Content_text = longreadDTO.Content,
            Author = user,
            Created = longreadDTO.CreatedAt
        };

        _dbContext.Add(longread);
        await _dbContext.SaveChangesAsync();
        return Ok(longread);
    }


    [HttpGet("ShowLongreads")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ShowAllLongreads(CancellationToken cancellationToken, [FromQuery] int start = 0, [FromQuery] int count = 10){
        var all = await _dbContext.Longreads
        .Include(l => l.Author)
        .Skip(start)
        .Take(count)
        .ToListAsync(cancellationToken);

        var result = all.Select(c => new GetLongreadDTO
        {
            Title = c.Title,
            AutorName = c.Author.Nickname, 
            CreatedAt = c.Created
        }).ToList();

        return Ok(result);
    }

    [HttpGet("ShowLongread{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetLongreadById(CancellationToken cancellationToken, [FromRoute] int id){
        var longread = await _dbContext.Longreads.FindAsync(id, cancellationToken);

        if(longread is null){
            return NotFound(id);
        }
        LongreadDTO longreadDTO = new LongreadDTO{
            AuthorId = longread.Author_id,
            CreatedAt = longread.Created,
            Title = longread.Title,
            Content = longread.Content_text
        };
        return Ok(longreadDTO);
    }

}
