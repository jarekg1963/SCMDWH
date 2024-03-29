﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;


using Microsoft.EntityFrameworkCore;


namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EshippingContainerController : ControllerBase
    {
        private readonly TPVStockContext _context;

        public EshippingContainerController(TPVStockContext context)
        {
            _context = context;
        }



        [HttpGet()]
        [Route("GetbyDateNoSent/{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<EshippingContainer>>> GetbyDateNoSent(string startDate, string endDate)
        {
            
            if (_context.EshippingContainers == null)
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


            try
            {
                var eShippingList = await _context.EshippingContainers.Where(d => d.Etd >= startDt && d.Etd <= endDt)
                    .OrderByDescending(c => c.Etd).ToListAsync();
                return eShippingList;
            }
            catch (Exception ex) 
            {
            return BadRequest(ex.Message);
            }

          
        }




        // GET: api/CarAdviceDictionaryCountryCodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EshippingContainer>>> GetEshippingContainers()
        {
            if (_context.EshippingContainers == null)
            {
                return NotFound();
            }
            return await _context.EshippingContainers.Take(100).ToListAsync();
        }

    }
}
