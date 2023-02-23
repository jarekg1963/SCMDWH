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
    public class CarAdviceDictionarySecurityPersonsController : ControllerBase
    {
        private readonly PurchasingContext _context;

        public CarAdviceDictionarySecurityPersonsController(PurchasingContext context)
        {
            _context = context;
        }

        // GET: api/CarAdviceDictionarySecurityPersons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarAdviceDictionarySecurityPerson>>> GetCarAdviceDictionarySecurityPerson()
        {
          if (_context.CarAdviceDictionarySecurityPersons == null)
          {
              return NotFound();
          }
            return await _context.CarAdviceDictionarySecurityPersons.ToListAsync();
        }

        // GET: api/CarAdviceDictionarySecurityPersons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarAdviceDictionarySecurityPerson>> GetCarAdviceDictionarySecurityPerson(long id)
        {
          if (_context.CarAdviceDictionarySecurityPersons == null)
          {
              return NotFound();
          }
            var carAdviceDictionarySecurityPerson = await _context.CarAdviceDictionarySecurityPersons.FindAsync(id);

            if (carAdviceDictionarySecurityPerson == null)
            {
                return NotFound();
            }

            return carAdviceDictionarySecurityPerson;
        }

        // PUT: api/CarAdviceDictionarySecurityPersons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarAdviceDictionarySecurityPerson(long id, CarAdviceDictionarySecurityPerson carAdviceDictionarySecurityPerson)
        {
            if (id != carAdviceDictionarySecurityPerson.Id)
            {
                return BadRequest();
            }

            _context.Entry(carAdviceDictionarySecurityPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarAdviceDictionarySecurityPersonExists(id))
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

        // POST: api/CarAdviceDictionarySecurityPersons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarAdviceDictionarySecurityPerson>> PostCarAdviceDictionarySecurityPerson(CarAdviceDictionarySecurityPerson carAdviceDictionarySecurityPerson)
        {
          if (_context.CarAdviceDictionarySecurityPersons == null)
          {
              return Problem("Entity set 'PurchasingContext.CarAdviceDictionarySecurityPerson'  is null.");
          }
            _context.CarAdviceDictionarySecurityPersons.Add(carAdviceDictionarySecurityPerson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarAdviceDictionarySecurityPerson", new { id = carAdviceDictionarySecurityPerson.Id }, carAdviceDictionarySecurityPerson);
        }

        // DELETE: api/CarAdviceDictionarySecurityPersons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarAdviceDictionarySecurityPerson(long id)
        {
            if (_context.CarAdviceDictionarySecurityPersons == null)
            {
                return NotFound();
            }
            var carAdviceDictionarySecurityPerson = await _context.CarAdviceDictionarySecurityPersons.FindAsync(id);
            if (carAdviceDictionarySecurityPerson == null)
            {
                return NotFound();
            }

            _context.CarAdviceDictionarySecurityPersons.Remove(carAdviceDictionarySecurityPerson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarAdviceDictionarySecurityPersonExists(long id)
        {
            return (_context.CarAdviceDictionarySecurityPersons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
