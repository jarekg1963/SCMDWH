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
    public class CarAdviceDictionaryCustomersController : ControllerBase
    {
        private readonly PurchasingContext _context;

        public CarAdviceDictionaryCustomersController(PurchasingContext context)
        {
            _context = context;
        }



    

            // GET: api/CarAdviceDictionaryCustomers
            [HttpGet]
        public async Task<ActionResult<IEnumerable<CarAdviceDictionaryCustomers>>> GetCarAdviceDictionaryCustomer()
        {
          if (_context.CarAdviceDictionaryCustomers == null)
          {
              return NotFound();
          }
            return await _context.CarAdviceDictionaryCustomers.ToListAsync();
        }


        [HttpGet("GetCarAdviceDictionaryActiveCustomer")]
        public async Task<ActionResult<IEnumerable<CarAdviceDictionaryCustomers>>> GetCarAdviceDictionaryActiveCustomer()
        {
            if (_context.CarAdviceDictionaryCustomers == null)
            {
                return NotFound();
            }
            return await _context.CarAdviceDictionaryCustomers.Where(c=>c.ActiveFlag==true).ToListAsync();
        }

        // GET: api/CarAdviceDictionaryCustomers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarAdviceDictionaryCustomers>> GetCarAdviceDictionaryCustomer(long id)
        {
          if (_context.CarAdviceDictionaryCustomers == null)
          { 
              return NotFound();
          }
            var carAdviceDictionaryCustomers = await _context.CarAdviceDictionaryCustomers.FindAsync(id);

            if (carAdviceDictionaryCustomers == null)
            {
                return NotFound();
            }

            return carAdviceDictionaryCustomers;
        }

        // PUT: api/CarAdviceDictionaryCustomers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarAdviceDictionaryCustomer(long id, CarAdviceDictionaryCustomers carAdviceDictionaryCustomer)
        {
            if (id != carAdviceDictionaryCustomer.Id)
            {
                return BadRequest();
            }

            _context.Entry(carAdviceDictionaryCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarAdviceDictionaryCustomerExists(id))
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

        // POST: api/CarAdviceDictionaryCustomers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarAdviceDictionaryCustomers>> PostCarAdviceDictionaryCustomer(CarAdviceDictionaryCustomers carAdviceDictionaryCustomer)
        {
          if (_context.CarAdviceDictionaryCustomers == null)
          {
              return Problem("Entity set 'PurchasingContext.CarAdviceDictionaryCustomer'  is null.");
          }
            _context.CarAdviceDictionaryCustomers.Add(carAdviceDictionaryCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarAdviceDictionaryCustomer", new { id = carAdviceDictionaryCustomer.Id }, carAdviceDictionaryCustomer);
        }

        // DELETE: api/CarAdviceDictionaryCustomers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarAdviceDictionaryCustomer(long id)
        {
            if (_context.CarAdviceDictionaryCustomers == null)
            {
                return NotFound();
            }
            var carAdviceDictionaryCustomer = await _context.CarAdviceDictionaryCustomers.FindAsync(id);
            if (carAdviceDictionaryCustomer == null)
            {
                return NotFound();
            }

            _context.CarAdviceDictionaryCustomers.Remove(carAdviceDictionaryCustomer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarAdviceDictionaryCustomerExists(long id)
        {
            return (_context.CarAdviceDictionaryCustomers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
