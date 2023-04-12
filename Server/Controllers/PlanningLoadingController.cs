using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanningLoadingController : ControllerBase
    {



        private readonly PurchasingContext _context;

        public PlanningLoadingController(PurchasingContext context)
        {
            _context = context;
        }


        [HttpDelete("DeleteListImports/{sFileName}")]

        public async Task<ActionResult> DeleteListImports(string sFileName)
        { 
           await _context.PlanningLoading.Where(c=>c.FileName.Equals(sFileName)).ExecuteDeleteAsync();
          return Ok();
        }


        [HttpGet("ListImports")]
        public async Task<List<string>> ListImports()
        {
            return await _context.PlanningLoading.Select(m=>m.FileName).Distinct().ToListAsync();
        }



        // GET: api/<PlanningLoadingController>
        [HttpGet]
        public async Task<List<PlanningLoading>> Get()
        {
            return await _context.PlanningLoading.ToListAsync();
        }


        // POST: api/CarAdviceDictionaryCarriers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostPlanningLoading(PlanningLoading planningLoading)
        {
            if (_context.PlanningLoading == null)
            {
                return Problem("Entity set 'PurchasingContext.CarAdviceDictionaryCarriers'  is null.");
            }
            _context.PlanningLoading.Add(planningLoading);
            await _context.SaveChangesAsync();

            return Ok();
        }

       
    }
}
