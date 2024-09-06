using BlazorAppCar.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class EnginesController : ControllerBase
{
    private readonly BlazorAppCarContext _context;

    public EnginesController(BlazorAppCarContext context)
    {
        _context = context;
    }

    // GET: api/engines
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Engine>>> GetEngines()
    {
        return await _context.Engine.ToListAsync();
    }

    // GET: api/engines/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Engine>> GetEngine(int id)
    {
        var engine = await _context.Engine.FindAsync(id);

        if (engine == null)
        {
            return NotFound();
        }

        return engine;
    }
}
