using Microsoft.AspNetCore.Mvc;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarAdviceGrMainPlanComumControllery : ControllerBase
    {

        private readonly PurchasingContext _context;

        public CarAdviceGrMainPlanComumControllery(PurchasingContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarAdviceGrMainPlanComum>>> GetCarAdviceGrMainPlanComum()
        {
            if (_context.CarAdviceGrMainPlanComum == null)
            {
                return NotFound();
            }
            return await _context.CarAdviceGrMainPlanComum.ToListAsync();
        }

        [HttpGet("GRMainPlanComumByUser/{sUserName}")]
        public async Task<ActionResult<List<CarAdviceGrMainPlanComum>>> GRMainPlanComumByUser(string sUserName)
        {
            if (_context.CarAdviceGrMainPlanComum == null)
            {
                return NotFound();
            }
            return await _context.CarAdviceGrMainPlanComum.OrderBy(o => o.OrderColumn).Where(c => c.UserName == sUserName).ToListAsync();
        }

        // PUT: api/CarAdviceMainPlanComums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarAdviceGrMainPlanComum(int id, CarAdviceGrMainPlanComum carAdviceGrMainPlanComum)
        {
            if (id != carAdviceGrMainPlanComum.Id)
            {
                return BadRequest();
            }

            _context.Entry(carAdviceGrMainPlanComum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarAdviceGRMainPlanComumExists(id))
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


        // POST: api/CarAdviceMainPlanComums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarAdviceGrMainPlanComum>> PostCarAdviceGrMainPlanComum(CarAdviceGrMainPlanComum carAdviceGrMainPlanComum)
        {
            if (_context.CarAdviceGrMainPlanComum == null)
            {
                return Problem("Entity set 'CarAdviceContext.CarAdviceMainPlanComum'  is null.");
            }
            _context.CarAdviceGrMainPlanComum.Add(carAdviceGrMainPlanComum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarAdviceMainPlanComum", new { id = carAdviceGrMainPlanComum.Id }, carAdviceGrMainPlanComum);
        }


        // DELETE: api/CarAdviceMainPlanComums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarAdviceGrMainPlanComum(int id)
        {
            if (_context.CarAdviceGrMainPlanComum == null)
            {
                return NotFound();
            }
            var carAdviceGrMainPlanComum = await _context.CarAdviceGrMainPlanComum.FindAsync(id);
            if (carAdviceGrMainPlanComum == null)
            {
                return NotFound();
            }

            _context.CarAdviceGrMainPlanComum.Remove(carAdviceGrMainPlanComum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarAdviceGRMainPlanComumExists(int id)
        {
            return (_context.CarAdviceGrMainPlanComum?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

      
     
    
    
}
