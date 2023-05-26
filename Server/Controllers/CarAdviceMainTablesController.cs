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
    public class CarAdviceMainTablesController : ControllerBase
    {
        private readonly CarAdviceContext _context;

        public CarAdviceMainTablesController(CarAdviceContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("FoundByReference/{reference}")]
        public bool FoundByReference(string reference)
        {
            var refernceFoud = _context.CarAdviceMainTables.FirstOrDefault(t => t.Reference == reference);

            if (refernceFoud == null) 
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        [HttpGet()]
        [Route("GetbyDateNoSent/{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<CarAdviceMainTable>>> GetCarAdviceMainTablesDateSelectionNoSent(string startDate, string endDate)
        {
            if (_context.CarAdviceMainTables == null)
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

            return await _context.CarAdviceMainTables.Where(d => d.Etd >= startDt && d.Etd <= endDt && d.PickingStatus != "Sent")
                .OrderByDescending(c => c.Etd).ToListAsync();
        }


        [HttpGet()]
        [Route("GetbyDate/{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<CarAdviceMainTable>>> GetCarAdviceMainTablesDateSelection(string startDate,string endDate)
        {
            if (_context.CarAdviceMainTables == null)
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

            return await _context.CarAdviceMainTables.Where(d=>d.Etd >= startDt && d.Etd <= endDt)
                .OrderByDescending(c => c.Etd).ToListAsync();
        }

        // GET: api/CarAdviceMainTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarAdviceMainTable>>> GetCarAdviceMainTables()
        {
          if (_context.CarAdviceMainTables == null)
          {
              return NotFound();
          }
            return await _context.CarAdviceMainTables.Take(1500).OrderByDescending(c=>c.Id).ToListAsync();
        }

        // GET: api/CarAdviceMainTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarAdviceMainTable>> GetCarAdviceMainTable(long id)
        {
          if (_context.CarAdviceMainTables == null)
          {
              return NotFound();
          }
            var carAdviceMainTable = await _context.CarAdviceMainTables.FindAsync(id);

            if (carAdviceMainTable == null)
            {
                return NotFound();
            }

            return carAdviceMainTable;
        }

        // PUT: api/CarAdviceMainTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarAdviceMainTable(long id, CarAdviceMainTable carAdviceMainTable)
        {
            if (id != carAdviceMainTable.Id)
            {
                return BadRequest();
            }
            _context.Entry(carAdviceMainTable).State = EntityState.Modified;
			try
			{
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarAdviceMainTableExists(id))
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



        [HttpPut("ByWH/{id}")]
        public async Task<IActionResult> PutCarAdviceMainTableByWH(long id, CarAdviceMainTable carAdviceMainTable)
        {
            if (id != carAdviceMainTable.Id)
            {
                return BadRequest();
            }
            //_context.Entry(carAdviceMainTable).State = EntityState.Modified;
            try
            {
                _context.Entry(carAdviceMainTable).Property("AdviceDate").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("FgDelayReason").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("PickingStatus").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("Client").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("Shipment").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("Reference").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("Destination").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("DriverWh").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("TruckPlatesWh").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("Forwarder").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("ForwarderInfo").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("Etd").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("EntryByWh").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("RemarksWh").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("LoadingDock").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("LeftTheDockTime").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("PickingTime").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("ScannedTime").IsModified = true;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
            return NoContent();
        }



        [HttpPut("BySH/{id}")]
        public async Task<IActionResult> PutCarAdviceMainTableBySH(long id, CarAdviceMainTable carAdviceMainTable)
        {
            if (id != carAdviceMainTable.Id)
            {
                return BadRequest();
            }
            //_context.Entry(carAdviceMainTable).State = EntityState.Modified;
            try
            {
                _context.Entry(carAdviceMainTable).Property("Ata").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("Quality").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("TruckType").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("DriverS").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("TruckPlatesS").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("TpvEnterTime").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("TpvExitTime").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("CallBy").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("RemarksS").IsModified = true;
                _context.Entry(carAdviceMainTable).Property("EntryByS").IsModified = true;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
            return NoContent();
        }







        // POST: api/CarAdviceMainTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarAdviceMainTable>> PostCarAdviceMainTable(CarAdviceMainTable carAdviceMainTable)
        {
          if (_context.CarAdviceMainTables == null)
          {
              return Problem("Entity set 'CarAdviceContext.CarAdviceMainTables'  is null.");
          }
            _context.CarAdviceMainTables.Add(carAdviceMainTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarAdviceMainTable", new { id = carAdviceMainTable.Id }, carAdviceMainTable);
        }

        // DELETE: api/CarAdviceMainTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarAdviceMainTable(long id)
        {
            if (_context.CarAdviceMainTables == null)
            {
                return NotFound();
            }
            var carAdviceMainTable = await _context.CarAdviceMainTables.FindAsync(id);
            if (carAdviceMainTable == null)
            {
                return NotFound();
            }

            _context.CarAdviceMainTables.Remove(carAdviceMainTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarAdviceMainTableExists(long id)
        {
            return (_context.CarAdviceMainTables?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
