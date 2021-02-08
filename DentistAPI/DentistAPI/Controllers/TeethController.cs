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
    public class TeethController : ControllerBase
    {
        private readonly DentistAPIContext _context;

        public TeethController(DentistAPIContext context)
        {
            _context = context;
        }

        // GET: api/Teeth
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tooth>>> GetTooth()
        {
            return await _context.Tooth.Include(x => x.ToothToothSurface).ThenInclude(x => x.Surface).ToListAsync();
        }

        // GET: api/Teeth/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tooth>> GetTooth(int id)
        {
            var tooth = await _context.Tooth.Include(x => x.ToothToothSurface).ThenInclude(x => x.Surface).FirstOrDefaultAsync(t => t.Id == id);

            if (tooth == null)
            {
                return NotFound();
            }

            return tooth;
        }

        // PUT: api/Teeth/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTooth(int id, Tooth tooth)
        {
            if (id != tooth.Id)
            {
                return BadRequest();
            }

            _context.Entry(tooth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToothExists(id))
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

        // POST: api/Teeth
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tooth>> PostTooth(Tooth tooth)
        {
            _context.Tooth.Add(tooth);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTooth", new { id = tooth.Id }, tooth);
        }

        // DELETE: api/Teeth/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTooth(int id)
        {
            var tooth = await _context.Tooth.FindAsync(id);
            if (tooth == null)
            {
                return NotFound();
            }

            _context.Tooth.Remove(tooth);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToothExists(int id)
        {
            return _context.Tooth.Any(e => e.Id == id);
        }
    }
}
