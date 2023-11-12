using APIFARM.Data;
using APIFARM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIFARM.Controllers
{
    [Route("api/Salaries")]
    [ApiController]
    public class SalariesController : ControllerBase
    {
        private readonly ApiFarmContext _context;

        public SalariesController(ApiFarmContext context)
        {
            _context = context;
        }

        // GET: api/Salaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salarie>>> GetAllSalaries()
        {
            return await _context.Salaries.ToListAsync();
        }

        // GET: api/Salaries/
        [HttpGet("{id}")]
        public async Task<ActionResult<Salarie>> GetSalarieById(int id)
        {
            var salarie = await _context.Salaries.FindAsync(id);
            if (salarie == null)
            {
                return NotFound();
            }
            return salarie;
        }

        // POST: api/Salaries
        [HttpPost]
        public async Task<ActionResult<Salarie>> AddSalarie(Salarie salarie)
        {
            _context.Salaries.Add(salarie);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSalarieById), new { id = salarie.Id }, salarie);
        }

        // PUT: api/Salaries/
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalarie(int id, Salarie salarie)
        {
            if (id != salarie.Id)
            {
                return BadRequest();
            }

            _context.Entry(salarie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Salaries.Any(e => e.Id == id))
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

        // DELETE: api/Salaries/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalarie(int id)
        {
            var salarie = await _context.Salaries.FindAsync(id);
            if (salarie == null)
            {
                return NotFound();
            }

            _context.Salaries.Remove(salarie);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
