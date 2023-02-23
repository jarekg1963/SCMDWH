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
    public class LogAppUserActivitiesController : ControllerBase
    {
        private readonly PurchasingContext _context;

        public LogAppUserActivitiesController(PurchasingContext context)
        {
            _context = context;
        }

        // GET: api/LogAppUserActivities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogAppUserActivity>>> GetLogAppUserActivity()
        {
          if (_context.LogAppUserActivity == null)
          {
              return NotFound();
          }
            return await _context.LogAppUserActivity.OrderByDescending(c=>c.ActivityTime).ToListAsync();
        }

        // GET: api/LogAppUserActivities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogAppUserActivity>> GetLogAppUserActivity(long id)
        {
          if (_context.LogAppUserActivity == null)
          {
              return NotFound();
          }
            var logAppUserActivity = await _context.LogAppUserActivity.FindAsync(id);

            if (logAppUserActivity == null)
            {
                return NotFound();
            }

            return logAppUserActivity;
        }

        // PUT: api/LogAppUserActivities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogAppUserActivity(long id, LogAppUserActivity logAppUserActivity)
        {
            if (id != logAppUserActivity.Id)
            {
                return BadRequest();
            }

            _context.Entry(logAppUserActivity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogAppUserActivityExists(id))
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

        // POST: api/LogAppUserActivities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LogAppUserActivity>> PostLogAppUserActivity(LogAppUserActivity logAppUserActivity)
        {
          if (_context.LogAppUserActivity == null)
          {
              return Problem("Entity set 'PurchasingContext.LogAppUserActivity'  is null.");
          }
            _context.LogAppUserActivity.Add(logAppUserActivity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogAppUserActivity", new { id = logAppUserActivity.Id }, logAppUserActivity);
        }

        // DELETE: api/LogAppUserActivities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogAppUserActivity(long id)
        {
            if (_context.LogAppUserActivity == null)
            {
                return NotFound();
            }
            var logAppUserActivity = await _context.LogAppUserActivity.FindAsync(id);
            if (logAppUserActivity == null)
            {
                return NotFound();
            }

            _context.LogAppUserActivity.Remove(logAppUserActivity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LogAppUserActivityExists(long id)
        {
            return (_context.LogAppUserActivity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
