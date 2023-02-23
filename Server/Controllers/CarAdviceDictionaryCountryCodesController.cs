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
    public class CarAdviceDictionaryCountryCodesController : ControllerBase
    {
        private readonly PurchasingContext _context;

        public CarAdviceDictionaryCountryCodesController(PurchasingContext context)
        {
            _context = context;
        }



        // GET: api/CarAdviceDictionaryCountryCodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarAdviceDictionaryCountryCode>>> GetCarAdviceDictionaryCountryCode()
        {
          if (_context.CarAdviceDictionaryCountryCodes == null)
          {
              return NotFound();
          }
            return await _context.CarAdviceDictionaryCountryCodes.ToListAsync();
        }

        // GET: api/CarAdviceDictionaryCountryCodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarAdviceDictionaryCountryCode>> GetCarAdviceDictionaryCountryCode(long id)
        {
          if (_context.CarAdviceDictionaryCountryCodes == null)
          {
              return NotFound();
          }
            var carAdviceDictionaryCountryCode = await _context.CarAdviceDictionaryCountryCodes.FindAsync(id);

            if (carAdviceDictionaryCountryCode == null)
            {
                return NotFound();
            }

            return carAdviceDictionaryCountryCode;
        }

        // PUT: api/CarAdviceDictionaryCountryCodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarAdviceDictionaryCountryCode(long id, CarAdviceDictionaryCountryCode carAdviceDictionaryCountryCode)
        {
            if (id != carAdviceDictionaryCountryCode.Id)
            {
                return BadRequest();
            }

            _context.Entry(carAdviceDictionaryCountryCode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarAdviceDictionaryCountryCodeExists(id))
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

        // POST: api/CarAdviceDictionaryCountryCodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarAdviceDictionaryCountryCode>> PostCarAdviceDictionaryCountryCode(CarAdviceDictionaryCountryCode carAdviceDictionaryCountryCode)
        {
          if (_context.CarAdviceDictionaryCountryCodes == null)
          {
              return Problem("Entity set 'PurchasingContext.CarAdviceDictionaryCountryCode'  is null.");
          }
            _context.CarAdviceDictionaryCountryCodes.Add(carAdviceDictionaryCountryCode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarAdviceDictionaryCountryCode", new { id = carAdviceDictionaryCountryCode.Id }, carAdviceDictionaryCountryCode);
        }

        // DELETE: api/CarAdviceDictionaryCountryCodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarAdviceDictionaryCountryCode(long id)
        {
            if (_context.CarAdviceDictionaryCountryCodes == null)
            {
                return NotFound();
            }
            var carAdviceDictionaryCountryCode = await _context.CarAdviceDictionaryCountryCodes.FindAsync(id);
            if (carAdviceDictionaryCountryCode == null)
            {
                return NotFound();
            }

            _context.CarAdviceDictionaryCountryCodes.Remove(carAdviceDictionaryCountryCode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarAdviceDictionaryCountryCodeExists(long id)
        {
            return (_context.CarAdviceDictionaryCountryCodes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
