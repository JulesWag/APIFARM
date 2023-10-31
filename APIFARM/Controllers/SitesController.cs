using APIFARM.Data;
using APIFARM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIFARM.Controllers
{
    [Route("api/Site")]
    [ApiController]
    public class SitesController : ControllerBase
    {
        private readonly ApiFarmContext _context;

        public SitesController(ApiFarmContext context)
        {
            _context = context;
        }

        // GET: api/sites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Site>>> GetSites()
        {
            return await _context.Sites.ToListAsync();
        }

        // GET: api/sites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Site>> GetSite(int id)
        {
            var site = await _context.Sites.FindAsync(id);
            if (site == null) return NotFound();
            return site;
        }

        // POST: api/sites
        [HttpPost]
        public async Task<ActionResult<Site>> CreateSite(Site site)
        {
            _context.Sites.Add(site);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSite), new { id = site.Id }, site);
        }

        // PUT: api/sites/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSite(int id, Site site)
        {
            if (id != site.Id) return BadRequest();
            _context.Entry(site).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/sites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSite(int id)
        {
            var site = await _context.Sites.FindAsync(id);
            if (site == null) return NotFound();
            _context.Sites.Remove(site);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
