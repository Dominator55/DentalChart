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
    public class ProcedureRecordsController : ControllerBase
    {
        private readonly DentistAPIContext _context;

        public ProcedureRecordsController(DentistAPIContext context)
        {
            _context = context;
        }

        // GET: api/ProcedureRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcedureRecord>>> GetProcedureRecords()
        {
            return await _context.ProcedureRecords.ToListAsync();
        }

        // GET: api/ProcedureRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProcedureRecord>> GetProcedureRecord(int id)
        {
            var procedureRecord = await _context.ProcedureRecords.FindAsync(id);

            if (procedureRecord == null)
            {
                return NotFound();
            }

            return procedureRecord;
        }

        // PUT: api/ProcedureRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcedureRecord(int id, ProcedureRecord procedureRecord)
        {
            if (id != procedureRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(procedureRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcedureRecordExists(id))
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

        // POST: api/ProcedureRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProcedureRecord>> PostProcedureRecord(ProcedureRecord procedureRecord)
        {
            procedureRecord.ToothRecord = _context.ToothRecords.First(t => t.Tooth.Localization == procedureRecord.ToothRecord.Tooth.Localization && t.Patient.Id == procedureRecord.Encounter.Patient.Id);
            procedureRecord.Encounter = _context.Encounter.Find(procedureRecord.Encounter.Id);
            procedureRecord.Procedure = _context.Procedures.Find(procedureRecord.Procedure.Id);
            _context.ProcedureRecords.Add(procedureRecord);
            await _context.SaveChangesAsync();

            return await _context.ProcedureRecords
                .Include(pr => pr.ToothRecord).ThenInclude(t => t.Tooth)
                .FirstOrDefaultAsync(d => d.Id == procedureRecord.Id);
        }

        // DELETE: api/ProcedureRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcedureRecord(int id)
        {
            var procedureRecord = await _context.ProcedureRecords.FindAsync(id);
            if (procedureRecord == null)
            {
                return NotFound();
            }

            _context.ProcedureRecords.Remove(procedureRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProcedureRecordExists(int id)
        {
            return _context.ProcedureRecords.Any(e => e.Id == id);
        }
    }
}
