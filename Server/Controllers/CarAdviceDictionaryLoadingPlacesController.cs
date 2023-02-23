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
    public class CarAdviceDictionaryLoadingPlacesController : ControllerBase
    {
        private readonly PurchasingContext _context;

        public CarAdviceDictionaryLoadingPlacesController(PurchasingContext context)
        {
            _context = context;
        }

        // GET: api/CarAdviceDictionaryLoadingPlaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarAdviceDictionaryLoadingPlace>>> GetCarAdviceDictionaryLoadingPlace()
        {
          if (_context.CarAdviceDictionaryLoadingPlace == null)
          {
              return NotFound();
          }
            return await _context.CarAdviceDictionaryLoadingPlace.ToListAsync();
        }

        // GET: api/CarAdviceDictionaryLoadingPlaces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarAdviceDictionaryLoadingPlace>> GetCarAdviceDictionaryLoadingPlace(long id)
        {
          if (_context.CarAdviceDictionaryLoadingPlace == null)
          {
              return NotFound();
          }
            var carAdviceDictionaryLoadingPlace = await _context.CarAdviceDictionaryLoadingPlace.FindAsync(id);

            if (carAdviceDictionaryLoadingPlace == null)
            {
                return NotFound();
            }

            return carAdviceDictionaryLoadingPlace;
        }

        // PUT: api/CarAdviceDictionaryLoadingPlaces/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarAdviceDictionaryLoadingPlace(long id, CarAdviceDictionaryLoadingPlace carAdviceDictionaryLoadingPlace)
        {
            if (id != carAdviceDictionaryLoadingPlace.Id)
            {
                return BadRequest();
            }

            _context.Entry(carAdviceDictionaryLoadingPlace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarAdviceDictionaryLoadingPlaceExists(id))
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

        // POST: api/CarAdviceDictionaryLoadingPlaces
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarAdviceDictionaryLoadingPlace>> PostCarAdviceDictionaryLoadingPlace(CarAdviceDictionaryLoadingPlace carAdviceDictionaryLoadingPlace)
        {
          if (_context.CarAdviceDictionaryLoadingPlace == null)
          {
              return Problem("Entity set 'PurchasingContext.CarAdviceDictionaryLoadingPlace'  is null.");
          }
            _context.CarAdviceDictionaryLoadingPlace.Add(carAdviceDictionaryLoadingPlace);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarAdviceDictionaryLoadingPlace", new { id = carAdviceDictionaryLoadingPlace.Id }, carAdviceDictionaryLoadingPlace);
        }

        // DELETE: api/CarAdviceDictionaryLoadingPlaces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarAdviceDictionaryLoadingPlace(long id)
        {
            if (_context.CarAdviceDictionaryLoadingPlace == null)
            {
                return NotFound();
            }
            var carAdviceDictionaryLoadingPlace = await _context.CarAdviceDictionaryLoadingPlace.FindAsync(id);
            if (carAdviceDictionaryLoadingPlace == null)
            {
                return NotFound();
            }

            _context.CarAdviceDictionaryLoadingPlace.Remove(carAdviceDictionaryLoadingPlace);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarAdviceDictionaryLoadingPlaceExists(long id)
        {
            return (_context.CarAdviceDictionaryLoadingPlace?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
