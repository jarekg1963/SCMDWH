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
            if (_context.CarAdviceGrDictionaryCarStatuses == null)
            {
                return NotFound();
            }
            return await _context.CarAdviceGrMainPlanComum.ToListAsync();
        }

        }

      
     
    
    
}
