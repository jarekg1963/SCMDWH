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
    public class CarAdviceDictionaryCarriersController : ControllerBase
    {
        private readonly PurchasingContext _context;

        public CarAdviceDictionaryCarriersController(PurchasingContext context)
        {
            _context = context;
        }




        // GET: api/CarAdviceDictionaryCarriers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarAdviceDictionaryCarriers>>> GetCarAdviceDictionaryCarriers()
        {
          if (_context.CarAdviceDictionaryCarriers == null)
          {
              return NotFound();
          }
            return await _context.CarAdviceDictionaryCarriers.ToListAsync();
        }



        [HttpGet("GetCarAdviceActiveDictionaryCarriers")]
        public async Task<ActionResult<IEnumerable<CarAdviceDictionaryCarriers>>> GetCarAdviceActiveDictionaryCarriers()
        {
            if (_context.CarAdviceDictionaryCarriers == null)
            {
                return NotFound();
            }
            return await _context.CarAdviceDictionaryCarriers.Where(c=>c.ActiveFlag == true).ToListAsync();
        }

        // GET: api/CarAdviceDictionaryCarriers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarAdviceDictionaryCarriers>> GetCarAdviceDictionaryCarriers(long id)
        {
          if (_context.CarAdviceDictionaryCarriers == null)
          {
              return NotFound();
          }
            var carAdviceDictionaryCarriers = await _context.CarAdviceDictionaryCarriers.FindAsync(id);

            if (carAdviceDictionaryCarriers == null)
            {
                return NotFound();
            }

            return carAdviceDictionaryCarriers;
        }

        // PUT: api/CarAdviceDictionaryCarriers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarAdviceDictionaryCarriers(long id, CarAdviceDictionaryCarriers carAdviceDictionaryCarriers)
        {
            if (id != carAdviceDictionaryCarriers.Id)
            {
                return BadRequest();
            }

            _context.Entry(carAdviceDictionaryCarriers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarAdviceDictionaryCarriersExists(id))
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

        // POST: api/CarAdviceDictionaryCarriers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarAdviceDictionaryCarriers>> PostCarAdviceDictionaryCarriers(CarAdviceDictionaryCarriers carAdviceDictionaryCarriers)
        {
          if (_context.CarAdviceDictionaryCarriers == null)
          {
              return Problem("Entity set 'PurchasingContext.CarAdviceDictionaryCarriers'  is null.");
          }
            _context.CarAdviceDictionaryCarriers.Add(carAdviceDictionaryCarriers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarAdviceDictionaryCarriers", new { id = carAdviceDictionaryCarriers.Id }, carAdviceDictionaryCarriers);
        }

        // DELETE: api/CarAdviceDictionaryCarriers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarAdviceDictionaryCarriers(long id)
        {
            if (_context.CarAdviceDictionaryCarriers == null)
            {
                return NotFound();
            }
            var carAdviceDictionaryCarriers = await _context.CarAdviceDictionaryCarriers.FindAsync(id);
            if (carAdviceDictionaryCarriers == null)
            {
                return NotFound();
            }

            _context.CarAdviceDictionaryCarriers.Remove(carAdviceDictionaryCarriers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarAdviceDictionaryCarriersExists(long id)
        {
            return (_context.CarAdviceDictionaryCarriers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
