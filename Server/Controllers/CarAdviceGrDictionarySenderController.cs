using Microsoft.AspNetCore.Mvc;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarAdviceGrDictionarySenderController : ControllerBase
    {

        private readonly PurchasingContext _context;

        public CarAdviceGrDictionarySenderController(PurchasingContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarAdviceGrDictionarySender>>> GetCarAdviceGrDictionarySender()
        {
            if (_context.CarAdviceGrDictionaryCarStatuses == null)
            {
                return NotFound();
            }
            return await _context.CarAdviceGrDictionarySender.Where(c => c.ActiveFlag == true).ToListAsync();
        }

        }

      
     
    
    
}
