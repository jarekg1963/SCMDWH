using Microsoft.AspNetCore.Mvc;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarAdviceGrDictionaryUnloadingPlaceController : ControllerBase
    {

        private readonly PurchasingContext _context;

        public CarAdviceGrDictionaryUnloadingPlaceController(PurchasingContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarAdviceGrDictionaryUnloadingPlace>>> GetCarAdviceGrDictionaryUnloadingPlace()
        {
            if (_context.CarAdviceGrDictionaryCarStatuses == null)
            {
                return NotFound();

            }


            try
            {
                return await _context.CarAdviceGrDictionaryUnloadingPlace.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

            
        }


        [HttpGet("GetActiveCarAdviceGrDictionaryUnloadingPlace")]
        public async Task<ActionResult<IEnumerable<CarAdviceGrDictionaryUnloadingPlace>>> GetActiveCarAdviceGrDictionaryUnloadingPlace()
        {
            if (_context.CarAdviceGrDictionaryCarStatuses == null)
            {
                return NotFound();
            }


            try
            {
                return await _context.CarAdviceGrDictionaryUnloadingPlace.Where(c => c.ActiveFlag == true).ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }    
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarAdviceGrDictionaryUnloadingPlace>> GetCarAdviceGrDictionaryUnloadingPlace(long id)
        {
            if (_context.CarAdviceGrDictionaryUnloadingPlace == null)
            {
                return NotFound();
            }
            var carAdviceGrDictionaryUnloadingPlace = await _context.CarAdviceGrDictionaryUnloadingPlace.FindAsync(id);

            if (carAdviceGrDictionaryUnloadingPlace == null)
            {
                return NotFound();
            }
            return carAdviceGrDictionaryUnloadingPlace;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarAdviceGrDictionaryUnloadingPlace(long id, CarAdviceGrDictionaryUnloadingPlace carAdviceGrDictionaryUnloadingPlace)
        {
            if (id != carAdviceGrDictionaryUnloadingPlace.Id)
            {
                return BadRequest();
            }
            _context.Entry(carAdviceGrDictionaryUnloadingPlace).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!CarAdviceGrDictionaryUnloadingPlaceExist(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(400, ex.Message);
                }
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CarAdviceGrDictionaryUnloadingPlace>> PostCarAdviceGrDictionaryUnloadingPlace(CarAdviceGrDictionaryUnloadingPlace carAdviceGrDictionaryUnloadingPlace)
        {
            if (_context.CarAdviceGrDictionaryUnloadingPlace == null)
            {
                return Problem("Entity set 'PurchasingContext.CarAdviceDictionaryCarriers'  is null.");
            }
            _context.CarAdviceGrDictionaryUnloadingPlace.Add(carAdviceGrDictionaryUnloadingPlace);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {

                return StatusCode(400, ex.Message);
            }
            return CreatedAtAction("GetCarAdviceGrDictionaryUnloadingPlace", new { id = carAdviceGrDictionaryUnloadingPlace.Id }, carAdviceGrDictionaryUnloadingPlace);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarAdviceGrDictionaryUnloadingPlace(long id)
        {
            if (_context.CarAdviceGrDictionaryUnloadingPlace == null)
            {
                return NotFound();
            }
            var carAdviceGrDictionaryUnloadingPlace = await _context.CarAdviceGrDictionaryUnloadingPlace.FindAsync(id);
            if (carAdviceGrDictionaryUnloadingPlace == null)
            {
                return NotFound();
            }
            try
            {
                _context.CarAdviceGrDictionaryUnloadingPlace.Remove(carAdviceGrDictionaryUnloadingPlace);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {

                return StatusCode(400, ex.Message);
            }
            return NoContent();
        }

        private bool CarAdviceGrDictionaryUnloadingPlaceExist(long id)
        {
            return (_context.CarAdviceGrDictionarySender?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
