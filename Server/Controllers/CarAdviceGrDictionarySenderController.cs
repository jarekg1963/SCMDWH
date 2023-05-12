﻿using Microsoft.AspNetCore.Mvc;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarAdviceGrDictionarySenderController : ControllerBase
    {

        private readonly PurchasingContext _context;

        public CarAdviceGrDictionarySenderController(PurchasingContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarAdviceGrDictionarySender>>> GetCarAdviceGrDictionarySender()
        {
            if (_context.CarAdviceGrDictionarySender == null)
            {
                return NotFound();
            }


            try
            {
                return await _context.CarAdviceGrDictionarySender.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }


        [HttpGet("GetActiveCarAdviceGrDictionarySender")]
        public async Task<ActionResult<IEnumerable<CarAdviceGrDictionarySender>>> GetActiveCarAdviceGrDictionarySender()
        {
            if (_context.CarAdviceGrDictionarySender == null)
            {
                return NotFound();
            }


			try
			{
				return await _context.CarAdviceGrDictionarySender.Where(c => c.ActiveFlag == true).ToListAsync();
			}
			catch (Exception ex)
			{
				return StatusCode(400, ex.Message);
			}	
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<CarAdviceGrDictionarySender>> GetCarAdviceGrDictionarySender(long id)
		{
			if (_context.CarAdviceGrDictionarySender == null)
			{
				return NotFound();
			}
			var carAdviceGrDictionarySender = await _context.CarAdviceGrDictionarySender.FindAsync(id);

			if (carAdviceGrDictionarySender == null)
			{
				return NotFound();
			}

			return carAdviceGrDictionarySender;
		}


		[HttpPut("{id}")]
		public async Task<IActionResult> PutCarAdviceGrDictionarySender(long id, CarAdviceGrDictionarySender carAdviceGrDictionarySender)
		{
			if (id != carAdviceGrDictionarySender.Id)
			{
				return BadRequest();
			}

			_context.Entry(carAdviceGrDictionarySender).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				if (!carAdviceGrDictionarySenderExist(id))
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
		public async Task<ActionResult<CarAdviceGrDictionarySender>> PostCarAdviceGrDictionarySender(CarAdviceGrDictionarySender carAdviceGrDictionarySender)
		{
			if (_context.CarAdviceGrDictionarySender == null)
			{
				return Problem("Entity set 'PurchasingContext.CarAdviceDictionaryCarriers'  is null.");
			}
			_context.CarAdviceGrDictionarySender.Add(carAdviceGrDictionarySender);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException ex) 
			{

				return StatusCode(400, ex.Message);
			}
			return CreatedAtAction("GetCarAdviceGrDictionarySender", new { id = carAdviceGrDictionarySender.Id }, carAdviceGrDictionarySender);
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCarAdviceGrDictionarySender(long id)
		{
			if (_context.CarAdviceGrDictionarySender == null)
			{
				return NotFound();
			}
			var carAdviceGrDictionarySender = await _context.CarAdviceGrDictionarySender.FindAsync(id);
			if (carAdviceGrDictionarySender == null)
			{
				return NotFound();
			}
			try
			{
				_context.CarAdviceGrDictionarySender.Remove(carAdviceGrDictionarySender);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException ex) 
			{

				return StatusCode(400, ex.Message);
			}
			return NoContent();
		}


		private bool carAdviceGrDictionarySenderExist(long id)
		{
			return (_context.CarAdviceGrDictionarySender?.Any(e => e.Id == id)).GetValueOrDefault();
		}

	}

      
     
    
    
}