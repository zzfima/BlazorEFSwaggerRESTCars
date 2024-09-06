using BlazorAppCar.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly BlazorAppCarContext _context;

    public CarsController(BlazorAppCarContext context)
    {
        _context = context;
    }

    // GET: api/cars
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Car>>> GetCars()
    {
        return await _context.Car.Include(c => c.Eng).ToListAsync();
    }

    // GET: api/cars/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Car>> GetCar(int id)
    {
        var car = await _context.Car.Include(c => c.Eng).FirstOrDefaultAsync(c => c.Id == id);

        if (car == null)
        {
            return NotFound();
        }

        return car;
    }
}
