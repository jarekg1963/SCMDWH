﻿using Microsoft.AspNetCore.Mvc;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;
using Microsoft.EntityFrameworkCore;
using SCMDWH.Shared.DTO;

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


        [HttpPost("ImportExcel")]
        public async Task<ActionResult> ImportExcel([FromBody] List<ImportGrExcel> excelImportedList)
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<CarAdviceGrTruckMainTable> AllCarsToAdd = new List<CarAdviceGrTruckMainTable>();
            foreach (List<ImportGrExcel> ExcelGroup in excelImportedList.GroupBy(EG => EG.CarNumber)
                                                          .OrderBy(group => group.Key)
                                                          .Select(group => group.ToList())
                                                          .ToList())
            {
                CarAdviceGrTruckMainTable CarToAdd = new CarAdviceGrTruckMainTable();
                ImportGrExcel ReferenceExcelLineFromGroup = ExcelGroup.FirstOrDefault();
                if (ReferenceExcelLineFromGroup == null) continue;
                if (ReferenceExcelLineFromGroup.DataEtd == null) ReferenceExcelLineFromGroup.DataEtd = DateTime.Now;
                if (ReferenceExcelLineFromGroup.HourEtd == null) ReferenceExcelLineFromGroup.HourEtd = DateTime.Now.TimeOfDay;
                DateTime DateInfo = (DateTime)ReferenceExcelLineFromGroup.DataEtd;
                DateInfo = DateInfo.Add((TimeSpan)ReferenceExcelLineFromGroup.HourEtd);

                CarToAdd.ETD = DateInfo;
                CarToAdd.Sender = ReferenceExcelLineFromGroup.Sender;
                CarToAdd.PickingStatus = "Nie dojechał";
                CarToAdd.AddByUser = "rcis";
                CarToAdd.AddDate = DateTime.Now;
                CarToAdd.ContainerNo = ReferenceExcelLineFromGroup.ContainerNo;

                foreach (ImportGrExcel item in ExcelGroup)
                {
                    if (item.InvoiceNo.Contains(","))
                    {
                        foreach (string subInvoiceNo in item.InvoiceNo.Split(","))
                        {
                            CarAdviceGrTruckItems itemToAdd = new();
                            itemToAdd.ContainerNo = item.ContainerNo;
                            itemToAdd.InvoiceNo = subInvoiceNo.Trim();
                            itemToAdd.Material = item.Material;
                            itemToAdd.TotalPalletQty = item.TotalPalletQty != null ? (int)item.TotalPalletQty : 0;
                            itemToAdd.TotalQty = item.TotalQty != null ? (int)item.TotalQty : 0;
                            itemToAdd.Remark = item.Remark;
                            CarToAdd.CarAdviceGrTruckItems.Add(itemToAdd);
                        }
                    }
                    else
                    { 
                        CarAdviceGrTruckItems itemToAdd = new();
                        itemToAdd.ContainerNo = item.ContainerNo;
                        itemToAdd.InvoiceNo = item.InvoiceNo;
                        itemToAdd.Material = item.Material;
                        itemToAdd.TotalPalletQty = item.TotalPalletQty != null ? (int)item.TotalPalletQty : 0;
                        itemToAdd.TotalQty = item.TotalQty != null ? (int)item.TotalQty : 0;
                        itemToAdd.Remark = item.Remark;
                        CarToAdd.CarAdviceGrTruckItems.Add(itemToAdd);
                    }
                }
                AllCarsToAdd.Add(CarToAdd);
            }
            if(!AllCarsToAdd.Any()) return Ok();
            foreach (CarAdviceGrTruckMainTable car in AllCarsToAdd)
            {
                _context.CarAdviceGrTruckMainTable.Add(car);
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPost("NewItemGr")]
        public async Task<ActionResult> NewItemGr([FromBody] CarAdviceGrTruckMainTable mainTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _context.CarAdviceGrTruckMainTable.Add(mainTable);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
            return Ok();
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
                return await _context.CarAdviceGrTruckMainTable.Include(C => C.CarAdviceGrTruckItems).
                    OrderByDescending(c => c.ETD).ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }


        [HttpGet()]
        [Route("GetGRbyDateNoLocated/{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<CarAdviceGrTruckMainTable>>> GetGRCarAdviceMainTablesDateSelectionNolocated(string startDate, string endDate)
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

            return await _context.CarAdviceGrTruckMainTable.Where(d => d.ETD >= startDt && d.ETD <= endDt && d.PickingStatus != "ULOKOWANE").Include(C => C.CarAdviceGrTruckItems)
                .OrderByDescending(c => c.ETD).ToListAsync();
        }


        [HttpGet()]
        [Route("GetGRbyDateAll/{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<CarAdviceGrTruckMainTable>>> GetGRCarAdviceMainTablesDateSelectionAll(string startDate, string endDate)
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

            return await _context.CarAdviceGrTruckMainTable.Where(d => d.ETD >= startDt && d.ETD <= endDt).Include(C => C.CarAdviceGrTruckItems)
                .OrderByDescending(c => c.ETD).ToListAsync();
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
              //  var carAdviceGrTruckMainTable = await _context.CarAdviceGrTruckMainTable.FindAsync(id);
             var carAdviceGrTruckMainTable = await _context.CarAdviceGrTruckMainTable.Include(d=>d.CarAdviceGrTruckItems).FirstOrDefaultAsync(c=>c.Id == id);


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
