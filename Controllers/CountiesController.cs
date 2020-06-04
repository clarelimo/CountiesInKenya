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
    public class CountiesController : ControllerBase
    {
        private readonly LegalContext _context;

        public CountiesController(LegalContext context)
        {
            _context = context;
        }

        // GET: api/Counties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<County>>> Getcounties()
        {
            return await _context.counties.ToListAsync();
        }

        // GET: api/Counties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<County>> GetCounty(int id)
        {
            var county = await _context.counties.FindAsync(id);

            if (county == null)
            {
                return NotFound();
            }

            return county;
        }

        // PUT: api/Counties/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCounty(int id, County county)
        {
            if (id != county.CountyID)
            {
                return BadRequest();
            }

            _context.Entry(county).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountyExists(id))
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

        // POST: api/Counties
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<County>> PostCounty(County county)
        {
            _context.counties.Add(county);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCounty", new { id = county.CountyID }, county);
        }

        // DELETE: api/Counties/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<County>> DeleteCounty(int id)
        {
            var county = await _context.counties.FindAsync(id);
            if (county == null)
            {
                return NotFound();
            }

            _context.counties.Remove(county);
            await _context.SaveChangesAsync();

            return county;
        }

        private bool CountyExists(int id)
        {
            return _context.counties.Any(e => e.CountyID == id);
        }
    }
}
