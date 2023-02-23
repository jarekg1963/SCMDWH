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
    public class CarAdviceDictionaryTruckTypesController : ControllerBase
    {
        private readonly PurchasingContext _context;

        public CarAdviceDictionaryTruckTypesController(PurchasingContext context)
        {
            _context = context;
        }

        // GET: api/CarAdviceDictionaryTruckTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarAdviceDictionaryTruckType>>> GetCarAdviceDictionaryTruckType()
        {
          if (_context.CarAdviceDictionaryTruckTypes == null)
          {
              return NotFound();
          }
            return await _context.CarAdviceDictionaryTruckTypes.ToListAsync();
        }

        [HttpGet("GetCarAdviceDictionaryActiveTruckType")]
        public async Task<ActionResult<IEnumerable<CarAdviceDictionaryTruckType>>> GetCarAdviceDictionaryActiveTruckType()
        {
            if (_context.CarAdviceDictionaryTruckTypes == null)
            {
                return NotFound();
            }
            return await _context.CarAdviceDictionaryTruckTypes.Where(c=>c.ActiveFlag == true).ToListAsync();
        }

        // GET: api/CarAdviceDictionaryTruckTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarAdviceDictionaryTruckType>> GetCarAdviceDictionaryTruckType(long id)
        {
          if (_context.CarAdviceDictionaryTruckTypes == null)
          {
              return NotFound();
          }
            var carAdviceDictionaryTruckType = await _context.CarAdviceDictionaryTruckTypes.FindAsync(id);

            if (carAdviceDictionaryTruckType == null)
            {
                return NotFound();
            }

            return carAdviceDictionaryTruckType;
        }

        // PUT: api/CarAdviceDictionaryTruckTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarAdviceDictionaryTruckType(long id, CarAdviceDictionaryTruckType carAdviceDictionaryTruckType)
        {
            if (id != carAdviceDictionaryTruckType.Id)
            {
                return BadRequest();
            }

            _context.Entry(carAdviceDictionaryTruckType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarAdviceDictionaryTruckTypeExists(id))
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

        // POST: api/CarAdviceDictionaryTruckTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarAdviceDictionaryTruckType>> PostCarAdviceDictionaryTruckType(CarAdviceDictionaryTruckType carAdviceDictionaryTruckType)
        {
          if (_context.CarAdviceDictionaryTruckTypes == null)
          {
              return Problem("Entity set 'PurchasingContext.CarAdviceDictionaryTruckType'  is null.");
          }
            _context.CarAdviceDictionaryTruckTypes.Add(carAdviceDictionaryTruckType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarAdviceDictionaryTruckType", new { id = carAdviceDictionaryTruckType.Id }, carAdviceDictionaryTruckType);
        }

        // DELETE: api/CarAdviceDictionaryTruckTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarAdviceDictionaryTruckType(long id)
        {
            if (_context.CarAdviceDictionaryTruckTypes == null)
            {
                return NotFound();
            }
            var carAdviceDictionaryTruckType = await _context.CarAdviceDictionaryTruckTypes.FindAsync(id);
            if (carAdviceDictionaryTruckType == null)
            {
                return NotFound();
            }

            _context.CarAdviceDictionaryTruckTypes.Remove(carAdviceDictionaryTruckType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarAdviceDictionaryTruckTypeExists(long id)
        {
            return (_context.CarAdviceDictionaryTruckTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
