using Microsoft.AspNetCore.Mvc;
using MiniPermit.Data;
using MiniPermit.Models;
using Microsoft.EntityFrameworkCore;

namespace MiniPermit.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermitController : ControllerBase
{
    private readonly AppDbContext _context;
    public PermitController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _context.Permits.ToListAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var permit = await _context.Permits.FindAsync(id);
        return permit == null ? NotFound() : Ok(permit);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Permit permit)
    {
        _context.Permits.Add(permit);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = permit.Id }, permit);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Permit updated)
    {
        var permit = await _context.Permits.FindAsync(id);
        if (permit == null) return NotFound();
        permit.Name = updated.Name;
        permit.Description = updated.Description;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var permit = await _context.Permits.FindAsync(id);
        if (permit == null) return NotFound();
        _context.Permits.Remove(permit);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
