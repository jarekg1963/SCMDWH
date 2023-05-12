using Microsoft.AspNetCore.Mvc;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SCMDWH.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarAdviceGrDictionaryCarStatusesController : ControllerBase
	{

		private readonly PurchasingContext _context;

		public CarAdviceGrDictionaryCarStatusesController(PurchasingContext context)
		{
			_context = context;
		}




		[HttpGet]
		public async Task<ActionResult<IEnumerable<CarAdviceGrDictionaryCarStatuses>>> GetCarAdviceGrDictionaryCarStatuses()
		{
			if (_context.CarAdviceGrDictionaryCarStatuses == null)
			{
				return NotFound();
			}
			return await _context.CarAdviceGrDictionaryCarStatuses.ToListAsync();
		}


		[HttpGet("GetActiveCarAdviceGrDictionaryCarStatuses")]
		public async Task<ActionResult<IEnumerable<CarAdviceGrDictionaryCarStatuses>>> GetActiveCarAdviceGrDictionaryCarStatuses()
		{
			if (_context.CarAdviceGrDictionaryCarStatuses == null)
			{
				return NotFound();
			}
			return await _context.CarAdviceGrDictionaryCarStatuses.Where(c => c.ActiveFlag == true).ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<CarAdviceGrDictionaryCarStatuses>> GetCarAdviceGrDictionaryCarStatuses(long id)
		{
			if (_context.CarAdviceGrDictionaryCarStatuses == null)
			{
				return NotFound();
			}
			var carAdviceGrDictionaryCarStatuses = await _context.CarAdviceGrDictionaryCarStatuses.FindAsync(id);

			if (carAdviceGrDictionaryCarStatuses == null)
			{
				return NotFound();
			}
			return carAdviceGrDictionaryCarStatuses;
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutCarAdviceGrDictionaryCarStatuses(long id, CarAdviceGrDictionaryCarStatuses carAdviceGrDictionaryCarStatuses)
		{
			if (id != carAdviceGrDictionaryCarStatuses.Id)
			{
				return BadRequest();
			}

			_context.Entry(carAdviceGrDictionaryCarStatuses).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				if (!GetCarAdviceGrDictionaryCarStatusesExist(id))
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
		public async Task<ActionResult<CarAdviceGrDictionaryCarStatuses>> PostCarAdviceGrDictionaryCarStatuses(CarAdviceGrDictionaryCarStatuses carAdviceGrDictionaryCarStatuses)
		{
			if (_context.CarAdviceGrDictionaryCarStatuses == null)
			{
				return Problem("Entity set 'PurchasingContext.CarAdviceDictionaryCarriers'  is null.");
			}
			_context.CarAdviceGrDictionaryCarStatuses.Add(carAdviceGrDictionaryCarStatuses);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException ex)
			{

				return StatusCode(400, ex.Message);
			}
			return CreatedAtAction("GetCarAdviceGrDictionaryCarStatuses", new { id = carAdviceGrDictionaryCarStatuses.Id }, carAdviceGrDictionaryCarStatuses);
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCarAdviceGrDictionaryCarStatuses(long id)
		{
			if (_context.CarAdviceGrDictionaryCarStatuses == null)
			{
				return NotFound();
			}
			var carAdviceGrDictionaryCarStatuses = await _context.CarAdviceGrDictionaryCarStatuses.FindAsync(id);
			if (carAdviceGrDictionaryCarStatuses == null)
			{
				return NotFound();
			}
			try
			{
				_context.CarAdviceGrDictionaryCarStatuses.Remove(carAdviceGrDictionaryCarStatuses);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException ex)
			{

				return StatusCode(400, ex.Message);
			}
			return NoContent();
		}


		private bool GetCarAdviceGrDictionaryCarStatusesExist(long id)
		{
			return (_context.CarAdviceGrDictionarySender?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}