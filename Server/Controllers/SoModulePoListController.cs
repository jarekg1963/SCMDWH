﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoModulePoListController : Controller
    {


        private readonly PurchasingContext _context;

        public SoModulePoListController(PurchasingContext context)
        {
            _context = context;
        }


        // GET: all PO PR So lisy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoModulePoList>>> GetSoModulePoList()
        {
            if (_context.SoModulePoList == null)
            {
                return NotFound();
            }
            return await _context.SoModulePoList.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<SoModulePoList>> SoModulePoList(SoModulePoList soModulePoList)
        {
            if (_context.SoModulePoList == null)
            {
                return Problem("Entity set 'SoModulePoList'  is null.");
            }
            _context.SoModulePoList.Add(soModulePoList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("SoModulePoList", new { id = soModulePoList.Id }, soModulePoList);
        }


        // GET: api/SoModulePoList/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SoModulePoList>> GetSoModulePoList(long id)
        {
            if (_context.SoModulePoList == null)
            {
                return NotFound();
            }
            var soModulePoList = await _context.SoModulePoList.FindAsync(id);

            if (soModulePoList == null)
            {
                return NotFound();
            }

            return soModulePoList;
        }



        // PUT: api/SoModulePoList/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoModulePoList(long id, SoModulePoList soModulePoList)
        {
            if (id != soModulePoList.Id)
            {
                return BadRequest();
            }

            _context.Entry(soModulePoList).State = EntityState.Modified;

          
                await _context.SaveChangesAsync();
           

            return NoContent();
        }


        // DELETE: api/SoModulePoList/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoModulePoList(long id)
        {
            if (_context.SoModulePoList == null)
            {
                return NotFound();
            }
            var soModulePoList = await _context.SoModulePoList.FindAsync(id);
            if (soModulePoList == null)
            {
                return NotFound();
            }

            _context.SoModulePoList.Remove(soModulePoList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
