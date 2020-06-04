using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KenyanCounties.Models;

namespace KenyanCounties.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCountiesController : ControllerBase
    {
        private readonly LegalContext _context;

        public SubCountiesController(LegalContext context)
        {
            _context = context;
        }

        // GET: api/SubCounties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCounty>>> GetSubCounty()
        {
            return await _context.SubCounty.ToListAsync();
        }

        // GET: api/SubCounties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCounty>> GetSubCounty(int id)
        {
            var subCounty = await _context.SubCounty.FindAsync(id);

            if (subCounty == null)
            {
                return NotFound();
            }

            return subCounty;
        }

        // PUT: api/SubCounties/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubCounty(int id, SubCounty subCounty)
        {
            if (id != subCounty.SubCountyID)
            {
                return BadRequest();
            }

            _context.Entry(subCounty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubCountyExists(id))
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

        // POST: api/SubCounties
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SubCounty>> PostSubCounty(SubCounty subCounty)
        {
            _context.SubCounty.Add(subCounty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubCounty", new { id = subCounty.SubCountyID }, subCounty);
        }

        // DELETE: api/SubCounties/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubCounty>> DeleteSubCounty(int id)
        {
            var subCounty = await _context.SubCounty.FindAsync(id);
            if (subCounty == null)
            {
                return NotFound();
            }

            _context.SubCounty.Remove(subCounty);
            await _context.SaveChangesAsync();

            return subCounty;
        }

        private bool SubCountyExists(int id)
        {
            return _context.SubCounty.Any(e => e.SubCountyID == id);
        }
    }
}
