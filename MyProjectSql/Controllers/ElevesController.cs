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
    public class ElevesController : ControllerBase
    {
        private readonly DataContext _context;

        public ElevesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Eleves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eleve>>> GetEleves()
        {
          if (_context.Eleves == null)
          {
              return NotFound();
          }
            return await _context.Eleves.ToListAsync();
        }

        // GET: api/Eleves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Eleve>> GetEleve(int id)
        {
          if (_context.Eleves == null)
          {
              return NotFound();
          }
            var eleve = await _context.Eleves.FindAsync(id);

            if (eleve == null)
            {
                return NotFound();
            }

            return eleve;
        }

        // PUT: api/Eleves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEleve(int id, Eleve eleve)
        {
            if (id != eleve.Id)
            {
                return BadRequest();
            }

            _context.Entry(eleve).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EleveExists(id))
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

        // POST: api/Eleves
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Eleve>> PostEleve(Eleve eleve)
        {
          if (_context.Eleves == null)
          {
              return Problem("Entity set 'DataContext.Eleves'  is null.");
          }
            _context.Eleves.Add(eleve);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEleve", new { id = eleve.Id }, eleve);
        }

        // DELETE: api/Eleves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEleve(int id)
        {
            if (_context.Eleves == null)
            {
                return NotFound();
            }
            var eleve = await _context.Eleves.FindAsync(id);
            if (eleve == null)
            {
                return NotFound();
            }

            _context.Eleves.Remove(eleve);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EleveExists(int id)
        {
            return (_context.Eleves?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
