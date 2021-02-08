using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DentistAPI;
using DentistAPI.Models;

namespace DentistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToothRecordsController : ControllerBase
    {
        private readonly DentistAPIContext _context;

        public ToothRecordsController(DentistAPIContext context)
        {
            _context = context;
        }

        // GET: api/ToothRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToothRecord>>> GetToothRecord()
        {
            return await _context.ToothRecord.ToListAsync();
        }

        // GET: api/ToothRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToothRecord>> GetToothRecord(int id)
        {
            var toothRecord = await _context.ToothRecord.FindAsync(id);

            if (toothRecord == null)
            {
                return NotFound();
            }

            return toothRecord;
        }

        // PUT: api/ToothRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToothRecord(int id, ToothRecord toothRecord)
        {
            if (id != toothRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(toothRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToothRecordExists(id))
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

        // POST: api/ToothRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToothRecord>> PostToothRecord(ToothRecord toothRecord)
        {
            _context.ToothRecord.Add(toothRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToothRecord", new { id = toothRecord.Id }, toothRecord);
        }

        // DELETE: api/ToothRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToothRecord(int id)
        {
            var toothRecord = await _context.ToothRecord.FindAsync(id);
            if (toothRecord == null)
            {
                return NotFound();
            }

            _context.ToothRecord.Remove(toothRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToothRecordExists(int id)
        {
            return _context.ToothRecord.Any(e => e.Id == id);
        }
    }
}
