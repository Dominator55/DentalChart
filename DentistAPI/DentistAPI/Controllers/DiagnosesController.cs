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
    public class DiagnosesController : ControllerBase
    {
        private readonly DentistAPIContext _context;

        public DiagnosesController(DentistAPIContext context)
        {
            _context = context;
        }

        // GET: api/Diagnoses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diagnosis>>> GetDiagnoses()
        {
            return await _context.Diagnoses.ToListAsync();
        }

        // GET: api/Diagnoses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diagnosis>> GetDiagnosis(int id)
        {
            var diagnosis = await _context.Diagnoses
                .Include(d=>d.ToothRecord).ThenInclude(t=>t.Tooth)
                .Include(d => d.ToothRecord).ThenInclude(t => t.ToothSurfaces)
                .Include(d => d.Encounter)
                .FirstOrDefaultAsync(d=>d.Id==id);

            if (diagnosis == null)
            {
                return NotFound();
            }

            return diagnosis;
        }

        // PUT: api/Diagnoses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Diagnosis>> PutDiagnosis(int id, Diagnosis diagnosis)
        {
            if (id != diagnosis.Id)
            {
                return BadRequest();
            }

            _context.Entry(diagnosis).State = EntityState.Modified;

            try
            {
                diagnosis.ToothRecord = _context.ToothRecords.First(t => t.Id == diagnosis.ToothRecord.Id);
                diagnosis.ClassificationOfDisease = _context.ClassificationOfDiseases.Find(diagnosis.ClassificationOfDisease.Id);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiagnosisExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return diagnosis;
        }

        // POST: api/Diagnoses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Diagnosis>> PostDiagnosis(Diagnosis diagnosis)
        {
            diagnosis.ToothRecord = _context.ToothRecords.First(t => t.Tooth.Localization == diagnosis.ToothRecord.Tooth.Localization && t.Patient.Id == diagnosis.Encounter.Patient.Id);
            diagnosis.Encounter = _context.Encounter.Find(diagnosis.Encounter.Id);
            diagnosis.ClassificationOfDisease = _context.ClassificationOfDiseases.Find(diagnosis.ClassificationOfDisease.Id);
            diagnosis.ToothSurfaces = new List<ToothSurfaceRecordDiagnosis>();
            _context.Diagnoses.Add(diagnosis);
            await _context.SaveChangesAsync();

            return await _context.Diagnoses
                .Include(d=>d.ToothRecord).ThenInclude(t=>t.Tooth)    
                .FirstOrDefaultAsync(d=>d.Id==diagnosis.Id);
        }

        // DELETE: api/Diagnoses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiagnosis(int id)
        {
            var diagnosis = await _context.Diagnoses.FindAsync(id);
            if (diagnosis == null)
            {
                return NotFound();
            }

            _context.Diagnoses.Remove(diagnosis);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiagnosisExists(int id)
        {
            return _context.Diagnoses.Any(e => e.Id == id);
        }
    }
}
