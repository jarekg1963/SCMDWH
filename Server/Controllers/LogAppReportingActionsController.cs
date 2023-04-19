using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogAppReportingActionsController : ControllerBase
    {
        private readonly PurchasingContext _context;

        public LogAppReportingActionsController(PurchasingContext context)
        {
            _context = context;
        }



        [HttpGet("GetListLogChanges/{IdError}")]
        public async Task<ActionResult<IEnumerable<CarAdviceMainTable>>> GetListLogChanges(int IdError)
        {
            LogAppReportingAction recordLog = new();

            List<LogAppReportingAction> listLog = new();

            List<CarAdviceMainTable> listMainScreen = new();

            CarAdviceMainTable oneMainScreen = new();


            recordLog = await _context.LogAppReportingActions.Where(c=>c.Id == IdError).FirstOrDefaultAsync();

            oneMainScreen = JsonSerializer.Deserialize<CarAdviceMainTable>(recordLog.ActionDetails);

            long idMainForSelect = (long)oneMainScreen.Id;

            listLog = await _context.LogAppReportingActions.ToListAsync();

            foreach (LogAppReportingAction action in listLog)
            {

                try
                {
                    oneMainScreen = JsonSerializer.Deserialize<CarAdviceMainTable>(action.ActionDetails);
                    if (oneMainScreen.Id == idMainForSelect)
                        listMainScreen.Add(oneMainScreen);
                }
                catch (Exception ex) 
                {
                  // return BadRequest(ex.Message);
                }
            }

            return listMainScreen;

        }
            
        
        // GET: api/LogAppReportingActions
            [HttpGet]
        public async Task<ActionResult<IEnumerable<LogAppReportingAction>>> GetLogAppReportingAction()
        {
          if (_context.LogAppReportingActions == null)
          {
              return NotFound();
          }
            return await _context.LogAppReportingActions.OrderByDescending(o=>o.ActionTime).ToListAsync();
        }

        // GET: api/LogAppReportingActions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogAppReportingAction>> GetLogAppReportingAction(long id)
        {
          if (_context.LogAppReportingActions == null)
          {
              return NotFound();
          }
            var logAppReportingAction = await _context.LogAppReportingActions.FindAsync(id);

            if (logAppReportingAction == null)
            {
                return NotFound();
            }

            return logAppReportingAction;
        }

        // PUT: api/LogAppReportingActions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogAppReportingAction(long id, LogAppReportingAction logAppReportingAction)
        {
            if (id != logAppReportingAction.Id)
            {
                return BadRequest();
            }

            

            _context.Entry(logAppReportingAction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogAppReportingActionExists(id))
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

        // POST: api/LogAppReportingActions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LogAppReportingAction>> PostLogAppReportingAction(LogAppReportingAction logAppReportingAction)
        {
          if (_context.LogAppReportingActions == null)
          {
              return Problem("Entity set 'PurchasingContext.LogAppReportingAction'  is null.");
          }

          
            _context.LogAppReportingActions.Add(logAppReportingAction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogAppReportingAction", new { id = logAppReportingAction.Id }, logAppReportingAction);
        }

        // DELETE: api/LogAppReportingActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogAppReportingAction(long id)
        {
            if (_context.LogAppReportingActions == null)
            {
                return NotFound();
            }
            var logAppReportingAction = await _context.LogAppReportingActions.FindAsync(id);
            if (logAppReportingAction == null)
            {
                return NotFound();
            }

            _context.LogAppReportingActions.Remove(logAppReportingAction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LogAppReportingActionExists(long id)
        {
            return (_context.LogAppReportingActions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
