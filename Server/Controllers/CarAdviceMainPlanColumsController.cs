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
    public class CarAdviceMainPlanColumsController : ControllerBase
    {
        private readonly CarAdviceContext _context;

        public CarAdviceMainPlanColumsController(CarAdviceContext context)
        {
            _context = context;
        }

        // GET: api/CarAdviceMainPlanComums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarAdviceMainPlanColumn>>> GetCarAdviceMainPlanComum()
        {
          if (_context.CarAdviceMainPlanComum == null)
          {
              return NotFound();
          }
            return await _context.CarAdviceMainPlanComum.ToListAsync();
        }


        [HttpGet("SOPRListComumByUser/{sUserName}")]
        public async Task<ActionResult<List<CarAdviceMainPlanColumn>>> SOPRListComumByUser(string sUserName)
        {
            if (_context.CarAdviceMainPlanComum == null)
            {
                return NotFound();
            }
            return await _context.CarAdviceMainPlanComum.OrderBy(o => o.OrderColumn).Where(c => c.UserName == sUserName && c.TableName == "SoPoPr").ToListAsync();
        }


        [HttpGet("MainPlanComumByUser/{sUserName}")]
        public async Task<ActionResult<List<CarAdviceMainPlanColumn>>> MainPlanComumByUser(string sUserName)
        {
            if (_context.CarAdviceMainPlanComum == null)
            {
                return NotFound();
            }
            return await _context.CarAdviceMainPlanComum.OrderBy(o=>o.OrderColumn).Where(c=>c.UserName == sUserName && c.TableName == "CaFG").ToListAsync();
        }


        // GET: api/CarAdviceMainPlanComums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarAdviceMainPlanColumn>> GetCarAdviceMainPlanComum(long id)
        {
          if (_context.CarAdviceMainPlanComum == null)
          {
              return NotFound();
          }
            var carAdviceMainPlanComum = await _context.CarAdviceMainPlanComum.FindAsync(id);

            if (carAdviceMainPlanComum == null)
            {
                return NotFound();
            }

            return carAdviceMainPlanComum;
        }

        // PUT: api/CarAdviceMainPlanComums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarAdviceMainPlanComum(int id, CarAdviceMainPlanColumn carAdviceMainPlanComum)
        {
            if (id != carAdviceMainPlanComum.Id)
            {
                return BadRequest();
            }

            _context.Entry(carAdviceMainPlanComum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarAdviceMainPlanComumExists(id))
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
        public async Task<ActionResult<CarAdviceMainPlanColumn>> PostCarAdviceMainPlanComum(CarAdviceMainPlanColumn carAdviceMainPlanComum)
        {
          if (_context.CarAdviceMainPlanComum == null)
          {
              return Problem("Entity set 'CarAdviceContext.CarAdviceMainPlanComum'  is null.");
          }
            _context.CarAdviceMainPlanComum.Add(carAdviceMainPlanComum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarAdviceMainPlanComum", new { id = carAdviceMainPlanComum.Id }, carAdviceMainPlanComum);
        }

        // DELETE: api/CarAdviceMainPlanComums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarAdviceMainPlanComum(int id)
        {
            if (_context.CarAdviceMainPlanComum == null)
            {
                return NotFound();
            }
            var carAdviceMainPlanComum = await _context.CarAdviceMainPlanComum.FindAsync(id);
            if (carAdviceMainPlanComum == null)
            {
                return NotFound();
            }

            _context.CarAdviceMainPlanComum.Remove(carAdviceMainPlanComum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarAdviceMainPlanComumExists(int id)
        {
            return (_context.CarAdviceMainPlanComum?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
