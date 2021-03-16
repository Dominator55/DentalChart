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
    public class ClassificationOfDiseasesController : ControllerBase
    {
        private readonly DentistAPIContext _context;

        public ClassificationOfDiseasesController(DentistAPIContext context)
        {
            _context = context;
        }

        // GET: api/ClassificationOfDiseases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassificationOfDisease>>> GetClassificationOfDiseases()
        {
            return await _context.ClassificationOfDiseases.ToListAsync();
        }

        // GET: api/ClassificationOfDiseases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassificationOfDisease>> GetClassificationOfDisease(int id)
        {
            var classificationOfDisease = await _context.ClassificationOfDiseases.FindAsync(id);

            if (classificationOfDisease == null)
            {
                return NotFound();
            }

            return classificationOfDisease;
        }

        // PUT: api/ClassificationOfDiseases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassificationOfDisease(int id, ClassificationOfDisease classificationOfDisease)
        {
            if (id != classificationOfDisease.Id)
            {
                return BadRequest();
            }

            _context.Entry(classificationOfDisease).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassificationOfDiseaseExists(id))
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

        // POST: api/ClassificationOfDiseases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClassificationOfDisease>> PostClassificationOfDisease(ClassificationOfDisease classificationOfDisease)
        {
            _context.ClassificationOfDiseases.Add(classificationOfDisease);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassificationOfDisease", new { id = classificationOfDisease.Id }, classificationOfDisease);
        }

        // DELETE: api/ClassificationOfDiseases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassificationOfDisease(int id)
        {
            var classificationOfDisease = await _context.ClassificationOfDiseases.FindAsync(id);
            if (classificationOfDisease == null)
            {
                return NotFound();
            }

            _context.ClassificationOfDiseases.Remove(classificationOfDisease);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassificationOfDiseaseExists(int id)
        {
            return _context.ClassificationOfDiseases.Any(e => e.Id == id);
        }
    }
}
