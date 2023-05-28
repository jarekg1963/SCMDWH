using Microsoft.AspNetCore.Mvc;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarAdviceGrTruckItemsControllery : ControllerBase
    {

        private readonly PurchasingContext _context;

        public CarAdviceGrTruckItemsControllery(PurchasingContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarAdviceGrTruckItems>>> GetCarAdviceGrTruckItems()
        {
            if (_context.CarAdviceGrDictionaryCarStatuses == null)
            {
                return NotFound();
            }
            return await _context.CarAdviceGrTruckItems.ToListAsync();
        }

        [HttpGet()]
        [Route("GetbyDateNoSent/{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<CarAdviceGrTruckItems>>> GetCarAdviceGrItemSelectionAll(string startDate, string endDate)
        {

            List<CarAdviceGrTruckItems> ListItem = new();

            List<CarAdviceGrTruckMainTable> ListGrMain = new();




            if (_context.CarAdviceGrTruckItems == null)
            {
                return NotFound();
            }

            int sYear = Int32.Parse(startDate.Substring(4, 4));
            int sDay = Int32.Parse(startDate.Substring(2, 2));
            int sMc = Int32.Parse(startDate.Substring(0, 2));
            DateTime startDt = new DateTime(sYear, sMc, sDay);

            int eYear = Int32.Parse(endDate.Substring(4, 4));
            int eDay = Int32.Parse(endDate.Substring(2, 2));
            int eMc = Int32.Parse(endDate.Substring(0, 2));
            DateTime endDt = new DateTime(eYear, eMc, eDay);

            //ListGrMain = await _context.CarAdviceGrTruckMainTable.Include(c=>c.CarAdviceGrTruckItems).Where(d=>d.ETD >= startDt && d.ETD <= endDt).ToListAsync();
            //_context.CarAdviceGrTruckItems.Where(c => c.Truck.ETD >= startDt && c.Truck.ETD <= endDt).ToListAsync();
            //foreach (var item in ListGrMain)
            //{
            //    ListItem.AddRange(item.CarAdviceGrTruckItems);
            //}

            return await _context.CarAdviceGrTruckItems.Where(c => c.Truck.ETD >= startDt && c.Truck.ETD <= endDt).ToListAsync(); ;

        }

    }
}
