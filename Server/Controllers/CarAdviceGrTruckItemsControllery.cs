using Microsoft.AspNetCore.Mvc;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using AutoMapper;
using SCMDWH.Shared.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarAdviceGrTruckItemsControllery : ControllerBase
    {

        private readonly PurchasingContext _context;
        private readonly IMapper _mapper;

        public CarAdviceGrTruckItemsControllery(PurchasingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        [Route("GetbyDateSent/{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<GrTruckItemsDTO>>> GetCarAdviceGrItemSent(string startDate, string endDate)
        {

            List<CarAdviceGrTruckItems> ListItem = new();
            GrTruckItemsDTO itemDto = new GrTruckItemsDTO();
            List<GrTruckItemsDTO> ListItemDto = new();
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

            //return await _context.CarAdviceGrTruckItems.Where(c => c.Truck.ETD >= startDt && c.Truck.ETD <= endDt).ToListAsync(); ;

            ListItem = await _context.CarAdviceGrTruckItems.Include(f => f.Truck).Where(c => c.Truck.ETD >= startDt && c.Truck.ETD <= endDt && c.Truck.PickingStatus != "Ulokowane")
                .ToListAsync();

            foreach (var item in ListItem)
            {
                //oneMainScreenExtended = _mapper.Map<CarAdviceLogExtended>(oneMainScreen);
                itemDto = _mapper.Map<GrTruckItemsDTO>(item);


                itemDto.EtdForDisplay = item.Truck.AddDate;

                ListItemDto.Add(itemDto);

            }

            return ListItemDto.ToArray();

        }


            [HttpGet()]
        [Route("GetbyDateNoSent/{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<GrTruckItemsDTO>>> GetCarAdviceGrItemSelectionAll(string startDate, string endDate)
        {

            List<CarAdviceGrTruckItems> ListItem = new();
            GrTruckItemsDTO itemDto = new GrTruckItemsDTO();
            List<GrTruckItemsDTO> ListItemDto = new();
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

            //return await _context.CarAdviceGrTruckItems.Where(c => c.Truck.ETD >= startDt && c.Truck.ETD <= endDt).ToListAsync(); ;

            ListItem = await _context.CarAdviceGrTruckItems.Include(f=>f.Truck).Where(c => c.Truck.ETD >= startDt && c.Truck.ETD <= endDt).ToListAsync(); 

            foreach (var item in ListItem) 
            {
                //oneMainScreenExtended = _mapper.Map<CarAdviceLogExtended>(oneMainScreen);
                itemDto = _mapper.Map<GrTruckItemsDTO>(item);


                itemDto.EtdForDisplay = item.Truck.AddDate;
               
                ListItemDto.Add(itemDto);

            }

            return ListItemDto.ToArray();

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarAdviceGrTruckItems(long id, CarAdviceGrTruckItems ItemForEdit)
        {
            if (id != ItemForEdit.Id)
            {
                return BadRequest();
            }
            _context.Entry(ItemForEdit).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                    return BadRequest(ex.Message);
            }
            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarAdviceGrTruckItems(long id)
        {
            if (_context.CarAdviceGrTruckItems == null)
            {
                return NotFound();
            }
            var carAdviceGrTruckItems = await _context.CarAdviceGrTruckItems.FindAsync(id);
            if (carAdviceGrTruckItems == null)
            {
                return NotFound();
            }

            _context.CarAdviceGrTruckItems.Remove(carAdviceGrTruckItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // GET: api/CarAdviceDictionaryCarriers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarAdviceGrTruckItems>> GetCarAdviceGrTruckItems(long id)
        {
            if (_context.CarAdviceDictionaryCarriers == null)
            {
                return NotFound();
            }
            var carAdviceGrTruckItems = await _context.CarAdviceGrTruckItems.FindAsync(id);

            if (carAdviceGrTruckItems == null)
            {
                return NotFound();
            }

            return carAdviceGrTruckItems;
        }

    }
}
