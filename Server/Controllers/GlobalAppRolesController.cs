using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCMDWH.Server.Data;
using SCMDWH.Server.Repository;
using SCMDWH.Shared.Models;

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalAppRolesController : ControllerBase
    {
        private readonly PurchasingContext _context;
        private readonly IRepoGlobalAppRoles _roleRepo;


        public GlobalAppRolesController(PurchasingContext context , IRepoGlobalAppRoles roleRepo)
        {
            _context = context;
            _roleRepo = roleRepo;
           
        }


        [HttpGet("RepoGlobalAppRoles")]
        public async Task<ActionResult<IEnumerable<GlobalAppRoles>>> RepoRoles()
        {
            return Ok(_roleRepo.GetRoles());
        }

        // GET: api/GlobalAppRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GlobalAppRoles>>> GetGlobalAppRoles()
        {

          if (_context.GlobalAppRoles == null)
          {
              return NotFound();
          }
            return await _context.GlobalAppRoles.ToListAsync();
        }

        // GET: api/GlobalAppRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GlobalAppRoles>> GetGlobalAppRoles(string id)
        {
          if (_context.GlobalAppRoles == null)
          {
              return NotFound();
          }
            var globalAppRoles = await _context.GlobalAppRoles.FindAsync(id);

            if (globalAppRoles == null)
            {
                return NotFound();
            }

            return globalAppRoles;
        }

        // PUT: api/GlobalAppRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGlobalAppRoles(string id, GlobalAppRoles globalAppRoles)
        {
            if (id != globalAppRoles.RoleName)
            {
                return BadRequest();
            }

            _context.Entry(globalAppRoles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GlobalAppRolesExists(id))
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

        // POST: api/GlobalAppRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GlobalAppRoles>> PostGlobalAppRoles(GlobalAppRoles globalAppRoles)
        {
          if (_context.GlobalAppRoles == null)
          {
              return Problem("Entity set 'PurchasingContext.GlobalAppRoles'  is null.");
          }
            _context.GlobalAppRoles.Add(globalAppRoles);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GlobalAppRolesExists(globalAppRoles.RoleName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGlobalAppRoles", new { id = globalAppRoles.RoleName }, globalAppRoles);
        }

        // DELETE: api/GlobalAppRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGlobalAppRoles(string id)
        {
            if (_context.GlobalAppRoles == null)
            {
                return NotFound();
            }
            var globalAppRoles = await _context.GlobalAppRoles.FindAsync(id);
            if (globalAppRoles == null)
            {
                return NotFound();
            }

            _context.GlobalAppRoles.Remove(globalAppRoles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GlobalAppRolesExists(string id)
        {
            return (_context.GlobalAppRoles?.Any(e => e.RoleName == id)).GetValueOrDefault();
        }
    }
}
