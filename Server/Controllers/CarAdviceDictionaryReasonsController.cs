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
    public class CarAdviceDictionaryReasonsController : ControllerBase
    {
        private readonly PurchasingContext _context;

        public CarAdviceDictionaryReasonsController(PurchasingContext context)
        {
            _context = context;
        }

        // GET: api/CarAdviceDictionaryReasons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarAdviceDictionaryReason>>> GetCarAdviceDictionaryReason()
        {
          if (_context.CarAdviceDictionaryReasons == null)
          {
              return NotFound();
          }
            return await _context.CarAdviceDictionaryReasons.ToListAsync();
        }


        // GET: api/CarAdviceDictionaryReasons
        [HttpGet("GetCarAdviceDictionaryActiveReason")]
        public async Task<ActionResult<IEnumerable<CarAdviceDictionaryReason>>> GetCarAdviceDictionaryActiveReason()
        {
            if (_context.CarAdviceDictionaryReasons == null)
            {
                return NotFound();
            }
            return await _context.CarAdviceDictionaryReasons.Where(c=>c.ActiveFlag == true).ToListAsync();
        }



        // GET: api/CarAdviceDictionaryReasons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarAdviceDictionaryReason>> GetCarAdviceDictionaryReason(long id)
        {
          if (_context.CarAdviceDictionaryReasons == null)
          {
              return NotFound();
          }
            var carAdviceDictionaryReason = await _context.CarAdviceDictionaryReasons.FindAsync(id);

            if (carAdviceDictionaryReason == null)
            {
                return NotFound();
            }

            return carAdviceDictionaryReason;
        }

        // PUT: api/CarAdviceDictionaryReasons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarAdviceDictionaryReason(long id, CarAdviceDictionaryReason carAdviceDictionaryReason)
        {
            if (id != carAdviceDictionaryReason.Id)
            {
                return BadRequest();
            }

            _context.Entry(carAdviceDictionaryReason).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarAdviceDictionaryReasonExists(id))
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

        // POST: api/CarAdviceDictionaryReasons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarAdviceDictionaryReason>> PostCarAdviceDictionaryReason(CarAdviceDictionaryReason carAdviceDictionaryReason)
        {
          if (_context.CarAdviceDictionaryReasons == null)
          {
              return Problem("Entity set 'PurchasingContext.CarAdviceDictionaryReason'  is null.");
          }
            _context.CarAdviceDictionaryReasons.Add(carAdviceDictionaryReason);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarAdviceDictionaryReason", new { id = carAdviceDictionaryReason.Id }, carAdviceDictionaryReason);
        }

        // DELETE: api/CarAdviceDictionaryReasons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarAdviceDictionaryReason(long id)
        {
            if (_context.CarAdviceDictionaryReasons == null)
            {
                return NotFound();
            }
            var carAdviceDictionaryReason = await _context.CarAdviceDictionaryReasons.FindAsync(id);
            if (carAdviceDictionaryReason == null)
            {
                return NotFound();
            }

            _context.CarAdviceDictionaryReasons.Remove(carAdviceDictionaryReason);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarAdviceDictionaryReasonExists(long id)
        {
            return (_context.CarAdviceDictionaryReasons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
