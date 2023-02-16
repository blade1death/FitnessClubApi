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
    [Route("api/Treners")]
    [ApiController]
    public class TrenersController : ControllerBase
    {
        private readonly TestContext _context;

        public TrenersController(TestContext context)
        {
            _context = context;
        }

        // GET: api/Treners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trener>>> GetTreners()
        {
            return await _context.Treners.ToListAsync();
        }

        // GET: api/Treners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trener>> GetTrener(int id)
        {
            var trener = await _context.Treners.FindAsync(id);

            if (trener == null)
            {
                return NotFound();
            }

            return trener;
        }

        // PUT: api/Treners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrener(int id, Trener trener)
        {
            if (id != trener.Identificatortrener)
            {
                return BadRequest();
            }

            _context.Entry(trener).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrenerExists(id))
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

        // POST: api/Treners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trener>> PostTrener(Trener trener)
        {
            _context.Treners.Add(trener);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrener", new { id = trener.Identificatortrener }, trener);
        }

        // DELETE: api/Treners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrener(int id)
        {
            var trener = await _context.Treners.FindAsync(id);
            if (trener == null)
            {
                return NotFound();
            }

            _context.Treners.Remove(trener);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrenerExists(int id)
        {
            return _context.Treners.Any(e => e.Identificatortrener == id);
        }
    }
}
