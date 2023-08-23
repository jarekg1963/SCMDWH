using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoModuleTruckListController : ControllerBase
    {
        private readonly PurchasingContext _context;

        public SoModuleTruckListController(PurchasingContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoModuleTruckList>>> GetSoModuleTruckList()
        {
            if (_context.SoModuleTruckList == null)
            {
                return NotFound();
            }
            return await _context.SoModuleTruckList.ToListAsync();
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<SoModuleTruckList>> GetSoModuleTruckList(long Id)
        {
            var foudedTruck = await _context.SoModuleTruckList.FirstOrDefaultAsync(c=>c.Id == Id);
            if (foudedTruck == null)
            { return NotFound(); }
            return foudedTruck;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoModuleTruckList(long id, SoModuleTruckList soModuleTruckList)
        {
            if (id != soModuleTruckList.Id)
            {
                return BadRequest();
            }

            _context.Entry(soModuleTruckList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoModuleTruckListExists(id))
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
        private bool SoModuleTruckListExists(long id)
        {
            return (_context.SoModuleTruckList?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
