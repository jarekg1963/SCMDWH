using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;


namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoModuleItemListController : ControllerBase
    {
        private readonly PurchasingContext _context;
        public SoModuleItemListController(PurchasingContext context)
        {
            _context = context;
           
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoModuleItemList>>> GetSoModuleItemList()
        {
            if (_context.SoModuleItemsList == null)
            {
                return NotFound();
            }
            return await _context.SoModuleItemsList.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<SoModuleItemList>> GetSoModuleItemList(long Id)
        {
            var fouded = await _context.SoModuleItemsList.FirstOrDefaultAsync(c => c.Id == Id);
            if (fouded == null)
            { return NotFound(); }
            return fouded;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoModuleItemList(long id, SoModuleItemList soModuleItemList)
        {

            if (!SoModuleItemListExists(id))
                {
                    return BadRequest();
                }

                soModuleItemList.Id = id;

            _context.Entry(soModuleItemList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoModuleItemListExists(id))
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

        [HttpPost]
        public async Task<ActionResult<SoModuleItemList>> PostSoModuleItemList(SoModuleItemList soModuleItemList)
        {
            if (_context.SoModuleItemsList == null)
            {
                return Problem("Entity set 'PurchasingContext.SoModuleItemList'  is null.");
            }
            _context.SoModuleItemsList.Add(soModuleItemList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarAdviceDictionaryCarriers", new { id = soModuleItemList.Id }, soModuleItemList);
        }


        [HttpDelete]

        public async Task<IActionResult> DeleteSoModuleItemList(long id)
        {
            if (_context.SoModuleItemsList == null)
            {
                return NotFound();
            }
            var soModuleItemList = await _context.SoModuleItemsList.FindAsync(id);
            if (soModuleItemList == null)
            {
                return NotFound();
            }

            _context.SoModuleItemsList.Remove(soModuleItemList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoModuleItemListExists(long id)
        {
            return (_context.SoModuleItemsList?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
