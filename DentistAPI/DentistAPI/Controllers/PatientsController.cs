﻿using DentistAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace DentistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly DentistAPIContext _context;

        public PatientsController(DentistAPIContext context)
        {
            _context = context;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatient()
        {
            return await _context.Patients.ToListAsync();
        }
 
        // GET: api/Patients/5
        [HttpGet("{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _context.Patients
                .Include(p => p.ToothRecords).ThenInclude(t => t.ToothSurfaces).ThenInclude(ts => ts.ToothSurface)
                .Include(p => p.ToothRecords).ThenInclude(t => t.Tooth)
                .Include(p => p.Encounters).ThenInclude(e => e.Diagnoses).ThenInclude(d=> d.ClassificationOfDisease)
                .Include(p => p.Encounters).ThenInclude(e => e.Diagnoses).ThenInclude(d => d.ToothRecord).ThenInclude(t=>t.Tooth)
                .Include(p => p.Encounters).ThenInclude(e => e.Diagnoses).ThenInclude(d=>d.Encounter)
                .Include(p => p.Encounters).ThenInclude(e => e.ProcedureRecords).ThenInclude(p => p.Procedure)
                .Include(p => p.Encounters).ThenInclude(e => e.ProcedureRecords).ThenInclude(p => p.ToothRecord).ThenInclude(t => t.Tooth)
                .Include(p => p.Encounters).ThenInclude(e => e.ProcedureRecords).ThenInclude(p => p.Encounter)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        // PUT: api/Patients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }
            try
            {
                _context.Entry(patient).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
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

        // POST: api/Patients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            List<Tooth> teeth = await _context.Teeth.Include(t => t.ToothToothSurface).ThenInclude(t => t.Surface).ToListAsync();
            patient.ToothRecords = new List<ToothRecord>();
            foreach (Tooth tooth in teeth)
            {
                ToothRecord toothRecord = new ToothRecord()
                {
                    Tooth = tooth,
                    Patient = patient,
                };
                List<ToothSurfaceRecord> toothSurfaceRecords = new List<ToothSurfaceRecord>();
                foreach (ToothToothSurface toothToothSurface in tooth.ToothToothSurface)
                {
                    ToothSurfaceRecord toothSurfaceRecord = new ToothSurfaceRecord()
                    {
                        ToothSurface = toothToothSurface.Surface,
                        ToothRecord = toothRecord
                    };
                   // _context.ToothSurfaceRecords.Add(toothSurfaceRecord);
                    toothSurfaceRecords.Add(toothSurfaceRecord);
                }
                toothRecord.ToothSurfaces = toothSurfaceRecords;
//                _context.ToothRecords.Add(toothRecord);
                patient.ToothRecords.Add(toothRecord);
            }
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }
    }
}
