using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalAppUsersParametersController : ControllerBase
    {
        private readonly PurchasingContext _context;

        public GlobalAppUsersParametersController(PurchasingContext context)
        {
            _context = context;
        }

        // GET: api/CarAdviceDictionaryCarriers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GlobalAppUsersParameters>>> GetGlobalAppUsersParameters()
        {
            if (_context.GlobalAppUsersParameters == null)
            {
                return NotFound();
            }
            return await _context.GlobalAppUsersParameters.ToListAsync();
        }

        // GET: api/CarAdviceDictionaryCarriers/5
        [HttpGet("{sUserName}")]
        public async Task<ActionResult<GlobalAppUsersParameters>> GetGlobalAppUsersParameters(string  sUserName)
        {
            if (_context.GlobalAppUsersParameters == null)
            {
                return NotFound();
            }
            var globalAppUsersParameters = await _context.GlobalAppUsersParameters.FirstOrDefaultAsync(c=>c.UserName == sUserName);

            if (globalAppUsersParameters == null)
            {
                return NotFound();
            }

            return globalAppUsersParameters;
        }

       


        [HttpPut("{sUserName}")]
        public async Task<IActionResult> PutGlobalAppUsersParameters(string sUserName, GlobalAppUsersParameters globalAppUsersParameters)
        {
            if (sUserName != globalAppUsersParameters.UserName)
            {
                return BadRequest();
            }

            _context.Entry(globalAppUsersParameters).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult> PostGlobalAppUsersParameters(GlobalAppUsersParameters globalAppUsersParameters)
        {
            if (_context.GlobalAppUsersParameters == null)
            {
                return Problem("Entity set 'PurchasingContext.CarAdviceDictionaryCarriers'  is null.");
            }

            if (GlobalAppUsersParametersExist(globalAppUsersParameters.UserName))
            {
                _context.Entry(globalAppUsersParameters).State = EntityState.Modified;
            }
            else
            {
                _context.GlobalAppUsersParameters.Add(globalAppUsersParameters);
            }


            
            await _context.SaveChangesAsync();

            return NoContent(); 
        }

        private bool GlobalAppUsersParametersExist(string userName)
        {
            return (_context.GlobalAppUsersParameters?.Any(e => e.UserName == userName)).GetValueOrDefault();
        }

    }
}
