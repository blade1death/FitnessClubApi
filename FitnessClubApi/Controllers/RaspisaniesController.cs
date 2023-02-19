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
    public class RaspisaniesController : ControllerBase
    {
        private readonly TestContext _context;

        public RaspisaniesController(TestContext context)
        {
            _context = context;
        }

        // GET: api/Raspisanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Raspisanie>>> GetRaspisanies()
        {
            return await _context.Raspisanies.ToListAsync();
        }

        // GET: api/Raspisanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Raspisanie>> GetRaspisanie(int id)
        {
            var raspisanie = await _context.Raspisanies.FindAsync(id);

            if (raspisanie == null)
            {
                return NotFound();
            }

            return raspisanie;
        }

        // PUT: api/Raspisanies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaspisanie(int id, Raspisanie raspisanie)
        {
            if (id != raspisanie.Identificatorraspisania)
            {
                return BadRequest();
            }

            _context.Entry(raspisanie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaspisanieExists(id))
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

        // POST: api/Raspisanies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Raspisanie>> PostRaspisanie(Raspisanie raspisanie)
        {
            _context.Raspisanies.Add(raspisanie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRaspisanie", new { id = raspisanie.Identificatorraspisania }, raspisanie);
        }

        // DELETE: api/Raspisanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRaspisanie(int id)
        {
            var raspisanie = await _context.Raspisanies.FindAsync(id);
            if (raspisanie == null)
            {
                return NotFound();
            }

            _context.Raspisanies.Remove(raspisanie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RaspisanieExists(int id)
        {
            return _context.Raspisanies.Any(e => e.Identificatorraspisania == id);
        }
    }
}
