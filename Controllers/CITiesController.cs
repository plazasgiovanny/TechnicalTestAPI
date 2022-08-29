using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalTestAPI.Entities;
using TechnicalTestAPI.GlobalModel;

namespace TechnicalTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CITiesController : ControllerBase
    {
        private readonly ModelDbContext _context;

        public CITiesController(ModelDbContext context)
        {
            _context = context;
        }

        // GET: api/CITies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CITY>>> GetCITies()
        {
            return await _context.CITies.ToListAsync();
        }

        // GET: api/CITies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CITY>> GetCITY(int id)
        {
            var cITY = await _context.CITies.FindAsync(id);

            if (cITY == null)
            {
                return NotFound();
            }

            return cITY;
        }

        // PUT: api/CITies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCITY(int id, CITY cITY)
        {
            if (id != cITY.CODE)
            {
                return BadRequest();
            }

            _context.Entry(cITY).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CITYExists(id))
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

        // POST: api/CITies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CITY>> PostCITY(CITY cITY)
        {
            _context.CITies.Add(cITY);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCITY", new { id = cITY.CODE }, cITY);
        }

        // DELETE: api/CITies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCITY(int id)
        {
            var cITY = await _context.CITies.FindAsync(id);
            if (cITY == null)
            {
                return NotFound();
            }

            _context.CITies.Remove(cITY);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CITYExists(int id)
        {
            return _context.CITies.Any(e => e.CODE == id);
        }
    }
}
