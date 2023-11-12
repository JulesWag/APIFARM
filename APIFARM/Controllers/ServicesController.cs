﻿using APIFARM.Data;
using APIFARM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIFARM.Controllers
{
    [Route("api/Services")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiFarmContext _context;

        public ServicesController(ApiFarmContext context)
        {
            _context = context;
        }

        // GET: api/services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            return await _context.Services.ToListAsync();
        }

        // GET: api/services/
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null) return NotFound();
            return service;
        }

        // POST: api/services
        [HttpPost]
        public async Task<ActionResult<Service>> CreateService(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetService), new { id = service.Id }, service);
        }

        // PUT: api/services/
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(int id, Service service)
        {
            if (id != service.Id) return BadRequest();
            _context.Entry(service).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/services/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null) return NotFound();
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
