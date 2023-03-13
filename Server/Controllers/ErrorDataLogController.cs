using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCMDWH.Server.Data;
using SCMDWH.Server.Repository;
using SCMDWH.Shared.Models;
using Microsoft.EntityFrameworkCore;



namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorDataLogController : ControllerBase
    {
        private readonly PurchasingContext _context;
        public ErrorDataLogController(PurchasingContext context)
        {
            _context = context;

        }

       [HttpDelete("DeleteAllErrors")]
        public async Task<IActionResult> DeleteAllErrors()
        {
            try
            {
                await _context.ErrorDataLog.ExecuteDeleteAsync();
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
    }


            [HttpGet]
        public async Task<ActionResult<IEnumerable<ErrorDataLog>>> GetErrorDataLog()
        {
            if (_context.ErrorDataLog == null)
            {
                return NotFound();
            }
            return await _context.ErrorDataLog.ToListAsync();

        }

        
        [HttpPost]
        public async Task<ActionResult<ErrorDataLog>> PostErrorDataLog(ErrorDataLog errorDataLog)
        {
            if (_context.ErrorDataLog == null)
            {
                return Problem("Entity set 'ErrorDataLog.ErrorDataLog'  is null.");
            }
            _context.ErrorDataLog.Add(errorDataLog);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("errorDataLog", new { id = errorDataLog.LogId });

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteError(long id)
        {
            if (_context.ErrorDataLog == null)
            {
                return NotFound();
            }
            var ErrorDataLogForDelete = await _context.ErrorDataLog.FindAsync(id);
            if (ErrorDataLogForDelete == null)
            {
                return NotFound();
            }

            _context.ErrorDataLog.Remove(ErrorDataLogForDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
