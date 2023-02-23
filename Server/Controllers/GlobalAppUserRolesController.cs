using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalAppUserRolesController : ControllerBase
    {
        private readonly PurchasingContext _context;

        public GlobalAppUserRolesController(PurchasingContext context)
        {
            _context = context;
        }

        // GET: api/GlobalAppUserRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GlobalAppUserRoles>>> GetGlobalAppUserRoles()
        {
          if (_context.GlobalAppUserRoles == null)
          {
              return NotFound();
          }
            return await _context.GlobalAppUserRoles.ToListAsync();
        }

        [HttpGet("findbyname/{userName}")]
        public async Task<ActionResult<IEnumerable<GlobalAppUserRoles>>> GetGlobalAppUserRolesfindbyname(string userName)
        {

            List<GlobalAppUserRoles> roleList = new List<GlobalAppUserRoles>();
            roleList =  await _context.GlobalAppUserRoles.Where(e=>e.UserName == userName).ToListAsync();

            if (roleList.Count == 0) 
            {
                return BadRequest("No roules defined ");
            }

            return await _context.GlobalAppUserRoles.Where(c => c.UserName == userName).OrderBy(t => t.UserName).ToListAsync();
        }

        // GET: api/GlobalAppUserRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GlobalAppUserRoles>> GetGlobalAppUserRoles(long id)
        {
          if (_context.GlobalAppUserRoles == null)
          {
              return NotFound();
          }
            var globalAppUserRoles = await _context.GlobalAppUserRoles.FindAsync(id);

            if (globalAppUserRoles == null)
            {
                return NotFound();
            }

            return globalAppUserRoles;
        }

        // PUT: api/GlobalAppUserRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGlobalAppUserRoles(long id, GlobalAppUserRoles globalAppUserRoles)
        {
            if (id != globalAppUserRoles.Id)
            {
                return BadRequest();
            }

            _context.Entry(globalAppUserRoles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GlobalAppUserRolesExists(id))
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

        // POST: api/GlobalAppUserRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GlobalAppUserRoles>> PostGlobalAppUserRoles(GlobalAppUserRoles globalAppUserRoles)
        {
          if (_context.GlobalAppUserRoles == null)
          {
              return Problem("Entity set 'PurchasingContext.GlobalAppUserRoles'  is null.");
          }
            _context.GlobalAppUserRoles.Add(globalAppUserRoles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGlobalAppUserRoles", new { id = globalAppUserRoles.Id }, globalAppUserRoles);
        }

        // DELETE: api/GlobalAppUserRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGlobalAppUserRoles(long id)
        {
            if (_context.GlobalAppUserRoles == null)
            {
                return NotFound();
            }
            var globalAppUserRoles = await _context.GlobalAppUserRoles.FindAsync(id);
            if (globalAppUserRoles == null)
            {
                return NotFound();
            }

            _context.GlobalAppUserRoles.Remove(globalAppUserRoles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GlobalAppUserRolesExists(long id)
        {
            return (_context.GlobalAppUserRoles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
