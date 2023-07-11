using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;


using Microsoft.EntityFrameworkCore;


namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EshippingContainersController : ControllerBase
    {
        private readonly TPVstockContext _context;

        public EshippingContainersController(TPVstockContext context)
        {
            _context = context;
        }



        // GET: api/CarAdviceDictionaryCountryCodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EshippingContainers>>> GetEshippingContainers()
        {
            if (_context.EshippingContainers == null)
            {
                return NotFound();
            }
            return await _context.EshippingContainers.Take(100).ToListAsync();
        }

    }
}
