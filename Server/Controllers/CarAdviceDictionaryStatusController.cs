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
    public class CarAdviceDictionaryStatusController : ControllerBase
    {
        private readonly PurchasingContext _context;

        public CarAdviceDictionaryStatusController(PurchasingContext context)
        {
            _context = context;
        }

        // GET: api/CarAdviceDictionaryStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarAdviceDictionaryStatus>>> GetCarAdviceDictionaryStatus()
        {
          if (_context.CarAdviceDictionaryStatuses == null)
          {
              return NotFound();
          }
            return await _context.CarAdviceDictionaryStatuses.ToListAsync();
        }

        // GET: api/CarAdviceDictionaryStatus
        [HttpGet("GetCarAdviceDictionaryActiveStatus")]
        public async Task<ActionResult<IEnumerable<CarAdviceDictionaryStatus>>> GetCarAdviceDictionaryActiveStatus()
        {
            if (_context.CarAdviceDictionaryStatuses == null)
            {
                return NotFound();
            }
            return await _context.CarAdviceDictionaryStatuses.Where(c=>c.ActiveFlag == true).ToListAsync();
        }

        // GET: api/CarAdviceDictionaryStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarAdviceDictionaryStatus>> GetCarAdviceDictionaryStatus(long id)
        {
          if (_context.CarAdviceDictionaryStatuses == null)
          {
              return NotFound();
          }
            var carAdviceDictionaryStatus = await _context.CarAdviceDictionaryStatuses.FindAsync(id);

            if (carAdviceDictionaryStatus == null)
            {
                return NotFound();
            }

            return carAdviceDictionaryStatus;
        }

        // PUT: api/CarAdviceDictionaryStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarAdviceDictionaryStatus(long id, CarAdviceDictionaryStatus carAdviceDictionaryStatus)
        {
            if (id != carAdviceDictionaryStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(carAdviceDictionaryStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarAdviceDictionaryStatusExists(id))
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

        // POST: api/CarAdviceDictionaryStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarAdviceDictionaryStatus>> PostCarAdviceDictionaryStatus(CarAdviceDictionaryStatus carAdviceDictionaryStatus)
        {
          if (_context.CarAdviceDictionaryStatuses == null)
          {
              return Problem("Entity set 'PurchasingContext.CarAdviceDictionaryStatus'  is null.");
          }
            _context.CarAdviceDictionaryStatuses.Add(carAdviceDictionaryStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarAdviceDictionaryStatus", new { id = carAdviceDictionaryStatus.Id }, carAdviceDictionaryStatus);
        }

        // DELETE: api/CarAdviceDictionaryStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarAdviceDictionaryStatus(long id)
        {
            if (_context.CarAdviceDictionaryStatuses == null)
            {
                return NotFound();
            }
            var carAdviceDictionaryStatus = await _context.CarAdviceDictionaryStatuses.FindAsync(id);
            if (carAdviceDictionaryStatus == null)
            {
                return NotFound();
            }

            _context.CarAdviceDictionaryStatuses.Remove(carAdviceDictionaryStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarAdviceDictionaryStatusExists(long id)
        {
            return (_context.CarAdviceDictionaryStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
