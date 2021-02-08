using DentistAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToothToothSurfacesController : ControllerBase
    {
        private readonly DentistAPIContext _context;

        public ToothToothSurfacesController(DentistAPIContext context)
        {
            _context = context;
        }

        // GET: api/ToothToothSurfaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToothToothSurface>>> GetToothToothSurface()
        {
            return await _context.ToothToothSurface.Include(x => x.Surface).Include(x => x.Tooth).ToListAsync();
        }

        // GET: api/ToothToothSurfaces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToothToothSurface>> GetToothToothSurface(int id)
        {
            var toothToothSurface = await _context.ToothToothSurface.FindAsync(id);

            if (toothToothSurface == null)
            {
                return NotFound();
            }

            return toothToothSurface;
        }

        // PUT: api/ToothToothSurfaces/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToothToothSurface(int id, ToothToothSurface toothToothSurface)
        {
            if (id != toothToothSurface.ToothId)
            {
                return BadRequest();
            }

            _context.Entry(toothToothSurface).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToothToothSurfaceExists(id))
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

        // POST: api/ToothToothSurfaces
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToothToothSurface>> PostToothToothSurface(ToothToothSurface toothToothSurface)
        {
            _context.ToothToothSurface.Add(toothToothSurface);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ToothToothSurfaceExists(toothToothSurface.ToothId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetToothToothSurface", new { id = toothToothSurface.ToothId }, toothToothSurface);
        }

        // DELETE: api/ToothToothSurfaces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToothToothSurface(int id)
        {
            var toothToothSurface = await _context.ToothToothSurface.FindAsync(id);
            if (toothToothSurface == null)
            {
                return NotFound();
            }

            _context.ToothToothSurface.Remove(toothToothSurface);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToothToothSurfaceExists(int id)
        {
            return _context.ToothToothSurface.Any(e => e.ToothId == id);
        }
    }
}
