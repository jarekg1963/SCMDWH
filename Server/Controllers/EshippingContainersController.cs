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



        [HttpGet()]
        [Route("GetbyDateNoSent/{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<EshippingContainers>>> GetbyDateNoSent(string startDate, string endDate)
        {
            if (_context.EshippingContainers == null)
            {
                return NotFound();
            }

            // 10272022

            int sYear = Int32.Parse(startDate.Substring(4, 4));
            int sDay = Int32.Parse(startDate.Substring(2, 2));
            int sMc = Int32.Parse(startDate.Substring(0, 2));
            DateTime startDt = new DateTime(sYear, sMc, sDay);

            int eYear = Int32.Parse(endDate.Substring(4, 4));
            int eDay = Int32.Parse(endDate.Substring(2, 2));
            int eMc = Int32.Parse(endDate.Substring(0, 2));
            DateTime endDt = new DateTime(eYear, eMc, eDay);

            return await _context.EshippingContainers.Where(d => d.Etd >= startDt && d.Etd <= endDt )
                .OrderByDescending(c => c.Etd).ToListAsync();
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
