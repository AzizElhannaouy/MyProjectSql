using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProjectSql.Data;
using MyProjectSql.Models;

namespace MyProjectSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesseursController : ControllerBase
    {
        private readonly DataContext _context;

        public ProfesseursController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Professeurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professeur>>> GetTeachers()
        {
          if (_context.Teachers == null)
          {
              return NotFound();
          }
            return await _context.Teachers.ToListAsync();
        }

        // GET: api/Professeurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Professeur>> GetProfesseur(int id)
        {
          if (_context.Teachers == null)
          {
              return NotFound();
          }
            var professeur = await _context.Teachers.FindAsync(id);

            if (professeur == null)
            {
                return NotFound();
            }

            return professeur;
        }

        // PUT: api/Professeurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesseur(int id, Professeur professeur)
        {
            if (id != professeur.Id)
            {
                return BadRequest();
            }

            _context.Entry(professeur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesseurExists(id))
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

        // POST: api/Professeurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Professeur>> PostProfesseur(Professeur professeur)
        {
          if (_context.Teachers == null)
          {
              return Problem("Entity set 'DataContext.Teachers'  is null.");
          }
            _context.Teachers.Add(professeur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfesseur", new { id = professeur.Id }, professeur);
        }

        // DELETE: api/Professeurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesseur(int id)
        {
            if (_context.Teachers == null)
            {
                return NotFound();
            }
            var professeur = await _context.Teachers.FindAsync(id);
            if (professeur == null)
            {
                return NotFound();
            }

            _context.Teachers.Remove(professeur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfesseurExists(int id)
        {
            return (_context.Teachers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
