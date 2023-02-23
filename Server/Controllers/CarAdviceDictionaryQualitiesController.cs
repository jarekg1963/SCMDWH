using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarAdviceDictionaryQualitiesController : ControllerBase
    {
        private readonly PurchasingContext _context;

        public CarAdviceDictionaryQualitiesController(PurchasingContext context)
        {
            _context = context;
        }

        // GET: api/CarAdviceDictionaryQualities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarAdviceDictionaryQuality>>> GetCarAdviceDictionaryQuality()
        {
          if (_context.CarAdviceDictionaryQuality == null)
          {
              return NotFound();
          }
            return await _context.CarAdviceDictionaryQuality.ToListAsync();
        }
       

        // GET: api/CarAdviceDictionaryQualities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarAdviceDictionaryQuality>> GetCarAdviceDictionaryQuality(int id)
        {
          if (_context.CarAdviceDictionaryQuality == null)
          {
              return NotFound();
          }
            var carAdviceDictionaryQuality = await _context.CarAdviceDictionaryQuality.FindAsync(id);

            if (carAdviceDictionaryQuality == null)
            {
                return NotFound();
            }

            return carAdviceDictionaryQuality;
        }

        // PUT: api/CarAdviceDictionaryQualities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarAdviceDictionaryQuality(int id, CarAdviceDictionaryQuality carAdviceDictionaryQuality)
        {
            if (id != carAdviceDictionaryQuality.Id)
            {
                return BadRequest();
            }

            _context.Entry(carAdviceDictionaryQuality).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarAdviceDictionaryQualityExists(id))
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

        // POST: api/CarAdviceDictionaryQualities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarAdviceDictionaryQuality>> PostCarAdviceDictionaryQuality(CarAdviceDictionaryQuality carAdviceDictionaryQuality)
        {
          if (_context.CarAdviceDictionaryQuality == null)
          {
              return Problem("Entity set 'PurchasingContext.CarAdviceDictionaryQuality'  is null.");
          }
            _context.CarAdviceDictionaryQuality.Add(carAdviceDictionaryQuality);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarAdviceDictionaryQuality", new { id = carAdviceDictionaryQuality.Id }, carAdviceDictionaryQuality);
        }

        // DELETE: api/CarAdviceDictionaryQualities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarAdviceDictionaryQuality(int id)
        {
            if (_context.CarAdviceDictionaryQuality == null)
            {
                return NotFound();
            }
            var carAdviceDictionaryQuality = await _context.CarAdviceDictionaryQuality.FindAsync(id);
            if (carAdviceDictionaryQuality == null)
            {
                return NotFound();
            }

            _context.CarAdviceDictionaryQuality.Remove(carAdviceDictionaryQuality);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarAdviceDictionaryQualityExists(int id)
        {
            return (_context.CarAdviceDictionaryQuality?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
