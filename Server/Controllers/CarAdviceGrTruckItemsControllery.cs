using Microsoft.AspNetCore.Mvc;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarAdviceGrTruckItemsControllery : ControllerBase
    {

        private readonly PurchasingContext _context;

        public CarAdviceGrTruckItemsControllery(PurchasingContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarAdviceGrTruckItems>>> GetCarAdviceGrTruckItems()
        {
            if (_context.CarAdviceGrDictionaryCarStatuses == null)
            {
                return NotFound();
            }
            return await _context.CarAdviceGrTruckItems.ToListAsync();
        }

        }

      
     
    
    
}
