using Microsoft.AspNetCore.Mvc;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarAdviceGrTruckMainTableController : ControllerBase
    {

        private readonly PurchasingContext _context;

        public CarAdviceGrTruckMainTableController(PurchasingContext context)
        {
            _context = context;
        }


        [HttpPost("NewItemGr")]

        public async Task<ActionResult> NewItemGr([FromBody] CarAdviceGrTruckMainTable mainTable)    
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // zapisac rekord w nagłowku 

            try
            {

                _context.CarAdviceGrTruckMainTable.Add(mainTable);
                _context.SaveChanges();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);

            }
            // odczytac Id z nagłowka 
            // Update listy itemów z Id nagłowka 
            // Post listy itemów

            return CreatedAtAction("DefaultApi", new { id = 0 }, mainTable);

           


        }


        public class parrent
        {
            public int IdParret { get; set; }
            public string NameParek { get; set; }
            public virtual ICollection<dziecko> DzieciLista { get; set; } = new List<dziecko>();
        }

        public class dziecko
        {
            public int IdDziecka { get; set; }
            public string OpisDziecka { get; set; }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarAdviceGrTruckMainTable>>> GetCarAdviceGrTruckMainTable()
        {
            if (_context.CarAdviceGrTruckMainTable == null)
            {
                return NotFound();
            }
            try
            {
                return await _context.CarAdviceGrTruckMainTable.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }      
        }


        [HttpGet()]
        [Route("GetGRbyDateNoSent/{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<CarAdviceGrTruckMainTable>>> GetGRCarAdviceMainTablesDateSelectionNoSent(string startDate, string endDate)
        {
            if (_context.CarAdviceGrTruckMainTable == null)
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

            return await _context.CarAdviceGrTruckMainTable.Where(d => d.AddDate >= startDt && d.AddDate <= endDt && d.Status != "Sent").Include(C=>C.carAdviceGrTruckItems)
                .OrderByDescending(c => c.AddDate).ToListAsync();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<CarAdviceGrTruckMainTable>> GetCarAdviceGrTruckMainTable(long id)
        {
            if (_context.CarAdviceGrTruckMainTable == null)
            {
                return NotFound();
            }

            try
            {
                var carAdviceGrTruckMainTable = await _context.CarAdviceGrTruckMainTable.FindAsync(id);
                if (carAdviceGrTruckMainTable == null)
                {
                    return NotFound();
                }
                return carAdviceGrTruckMainTable;
            }
            catch (Exception ex) 
            {
                return StatusCode(400, ex.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGetCarAdviceGrTruckMainTable(long id, CarAdviceGrTruckMainTable carAdviceGrTruckMainTable)
        {
            if (id != carAdviceGrTruckMainTable.Id)
            {
                return BadRequest();
            }
            _context.Entry(carAdviceGrTruckMainTable).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!GetCarAdviceGrTruckMainTableExist(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(400, ex.Message);
                }
            }
            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<CarAdviceGrTruckMainTable>> PostGetCarAdviceGrTruckMainTable(CarAdviceGrTruckMainTable carAdviceGrTruckMainTable)
        {
            if (_context.CarAdviceGrTruckMainTable == null)
            {
                return Problem("Entity set 'PurchasingContext.CarAdviceDictionaryCarriers'  is null.");
            }
            _context.CarAdviceGrTruckMainTable.Add(carAdviceGrTruckMainTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {

                return StatusCode(400, ex.Message);
            }
            return CreatedAtAction("GetCarAdviceGrTruckMainTable", new { id = carAdviceGrTruckMainTable.Id }, carAdviceGrTruckMainTable);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarAdviceGrTruckMainTable(long id)
        {
            if (_context.CarAdviceGrTruckMainTable == null)
            {
                return NotFound();
            }
            var carAdviceGrTruckMainTable = await _context.CarAdviceGrTruckMainTable.FindAsync(id);
            if (carAdviceGrTruckMainTable == null)
            {
                return NotFound();
            }
            try
            {
                _context.CarAdviceGrTruckMainTable.Remove(carAdviceGrTruckMainTable);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {

                return StatusCode(400, ex.Message);
            }
            return NoContent();
        }


        private bool GetCarAdviceGrTruckMainTableExist(long id)
        {
            return (_context.CarAdviceGrTruckMainTable?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
