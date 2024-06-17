using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarbershopApi.Data;
using BarbershopApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BarbershopApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BarbersController : ControllerBase
{
    private readonly BarbershopContext _context;

    public BarbersController(BarbershopContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Barber>>> GetBarbers()
    {
        return await _context.Barbers.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Barber>> GetBarber(int id)
    {
        var barber = await _context.Barbers.FindAsync(id);

        if (barber == null)
        {
            return NotFound();
        }

        return barber;
    }

    [HttpPost]
    public async Task<ActionResult<Barber>> PostBarber(Barber barber)
    {
        _context.Barbers.Add(barber);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBarber), new { id = barber.Id }, barber);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutBarber(int id, Barber barber)
    {
        if (id != barber.Id)
        {
            return BadRequest();
        }

        _context.Entry(barber).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BarberExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBarber(int id)
    {
        var barber = await _context.Barbers.FindAsync(id);
        if (barber == null)
        {
            return NotFound();
        }

        _context.Barbers.Remove(barber);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost("import")]
    public async Task<IActionResult> ImportBarbers(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("File is empty");
        }

        using (var stream = new StreamReader(file.OpenReadStream()))
        {
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                var values = line.Split(',');
                var barber = new Barber { Name = values[0] };
                _context.Barbers.Add(barber);
            }
            await _context.SaveChangesAsync();
        }

        return NoContent();
    }

    private bool BarberExists(int id)
    {
        return _context.Barbers.Any(e => e.Id == id);
    }
}
