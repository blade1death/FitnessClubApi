using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessClubApi.Models;

namespace FitnessClubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GruppasController : ControllerBase
    {
        private readonly TestContext _context;

        public GruppasController(TestContext context)
        {
            _context = context;
        }

        // GET: api/Gruppas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gruppa>>> GetGruppas()
        {
            return await _context.Gruppas.ToListAsync();
        }

        // GET: api/Gruppas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gruppa>> GetGruppa(string id)
        {
            var gruppa = await _context.Gruppas.FindAsync(id);

            if (gruppa == null)
            {
                return NotFound();
            }

            return gruppa;
        }

        // PUT: api/Gruppas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGruppa(string id, Gruppa gruppa)
        {
            if (id != gruppa.Названиеgruppi)
            {
                return BadRequest();
            }

            _context.Entry(gruppa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GruppaExists(id))
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

        // POST: api/Gruppas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gruppa>> PostGruppa(Gruppa gruppa)
        {
            _context.Gruppas.Add(gruppa);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GruppaExists(gruppa.Названиеgruppi))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGruppa", new { id = gruppa.Названиеgruppi }, gruppa);
        }

        // DELETE: api/Gruppas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGruppa(string id)
        {
            var gruppa = await _context.Gruppas.FindAsync(id);
            if (gruppa == null)
            {
                return NotFound();
            }

            _context.Gruppas.Remove(gruppa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GruppaExists(string id)
        {
            return _context.Gruppas.Any(e => e.Названиеgruppi == id);
        }
    }
}
