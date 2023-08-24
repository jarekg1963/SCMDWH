using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;


namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoMainColumnController : ControllerBase
    {
        private readonly PurchasingContext _context;
        public SoMainColumnController(PurchasingContext context)
        {
            _context = context;
           
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoModuleGroupColumn>>> GetSoModuleGroupColumn()
        {
            if (_context.SoModuleItemsList == null)
            {
                return NotFound();
            }
            return await _context.SoModuleGroupColumn.ToListAsync();
        }

		[HttpGet("SOMainUser/{sUserName}")]
		public async Task<ActionResult<List<SoModuleGroupColumn>>> GetSoModuleGroupColumnByUser(string sUserName)
		{
			if (_context.CarAdviceMainPlanComum == null)
			{
				return NotFound();
			}
			return await _context.SoModuleGroupColumn.OrderBy(o => o.OrderColumn).Where(c => c.UserName == sUserName ).ToListAsync();
		}

		[HttpGet("{Id}")]
        public async Task<ActionResult<SoModuleGroupColumn>> GetSoModuleGroupColumn(long Id)
        {
            var fouded = await _context.SoModuleGroupColumn.FirstOrDefaultAsync(c => c.Id == Id);
            if (fouded == null)
            { return NotFound(); }
            return fouded;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoModuleGroupColumn(long id, SoModuleGroupColumn soModuleGroupColumn)
        {

            if (!SoModuleGroupColumnExist(id))
            {
                return BadRequest();
            }

            soModuleGroupColumn.Id = id;

            _context.Entry(soModuleGroupColumn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoModuleGroupColumnExist(id))
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
        public async Task<ActionResult<SoModuleGroupColumn>> PostSoModuleItemList(SoModuleGroupColumn soModuleGroupColumn)
        {
            if (_context.SoModuleGroupColumn == null)
            {
                return Problem("Entity set 'PurchasingContext.SoModuleGroupColumn'  is null.");
            }
            _context.SoModuleGroupColumn.Add(soModuleGroupColumn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("SoModuleGroupColumn", new { id = soModuleGroupColumn.Id }, soModuleGroupColumn);
        }


        [HttpDelete]

        public async Task<IActionResult> DeleteSoModuleGroupColumn(long id)
        {
            if (_context.SoModuleGroupColumn == null)
            {
                return NotFound();
            }
            var soModuleGroupColumn = await _context.SoModuleGroupColumn.FindAsync(id);
            if (soModuleGroupColumn == null)
            {
                return NotFound();
            }

            _context.SoModuleGroupColumn.Remove(soModuleGroupColumn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoModuleGroupColumnExist(long id)
        {
            return (_context.SoModuleGroupColumn?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
