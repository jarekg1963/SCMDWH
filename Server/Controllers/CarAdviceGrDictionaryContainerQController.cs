using Microsoft.AspNetCore.Mvc;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarAdviceGrDictionaryContainerQController : ControllerBase
    {

        private readonly PurchasingContext _context;

        public CarAdviceGrDictionaryContainerQController(PurchasingContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarAdviceGrDictionaryContainerQ>>> CarAdviceGrDictionaryContainerQ()
        {
            if (_context.CarAdviceGrDictionaryContainerQ == null)
            {
                return NotFound();
            }
            try
            {
                return await _context.CarAdviceGrDictionaryContainerQ.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }




		[HttpGet("{id}")]
		public async Task<ActionResult<CarAdviceGrDictionaryContainerQ>> CarAdviceGrDictionaryContainerQ(long id)
		{
			if (_context.CarAdviceGrDictionaryContainerQ == null)
			{
				return NotFound();
			}
			var carAdviceGrDictionaryContainerQ = await _context.CarAdviceGrDictionaryContainerQ.FindAsync(id);

			if (carAdviceGrDictionaryContainerQ == null)
			{
				return NotFound();
			}

			return carAdviceGrDictionaryContainerQ;
		}


		//[HttpPut("{id}")]
		//public async Task<IActionResult> PutCarAdviceGrDictionarySender(long id, CarAdviceGrDictionarySender carAdviceGrDictionarySender)
		//{
		//	if (id != carAdviceGrDictionarySender.Id)
		//	{
		//		return BadRequest();
		//	}

		//	_context.Entry(carAdviceGrDictionarySender).State = EntityState.Modified;

		//	try
		//	{
		//		await _context.SaveChangesAsync();
		//	}
		//	catch (DbUpdateConcurrencyException ex)
		//	{
		//		if (!carAdviceGrDictionarySenderExist(id))
		//		{
		//			return NotFound();
		//		}
		//		else
		//		{
		//			return StatusCode(400, ex.Message);
		//		}
		//	}

		//	return NoContent();
		//}


		//[HttpPost]
		//public async Task<ActionResult<CarAdviceGrDictionarySender>> PostCarAdviceGrDictionarySender(CarAdviceGrDictionarySender carAdviceGrDictionarySender)
		//{
		//	if (_context.CarAdviceGrDictionarySender == null)
		//	{
		//		return Problem("Entity set 'PurchasingContext.CarAdviceDictionaryCarriers'  is null.");
		//	}
		//	_context.CarAdviceGrDictionarySender.Add(carAdviceGrDictionarySender);
		//	try
		//	{
		//		await _context.SaveChangesAsync();
		//	}
		//	catch (DbUpdateException ex) 
		//	{

		//		return StatusCode(400, ex.Message);
		//	}
		//	return CreatedAtAction("GetCarAdviceGrDictionarySender", new { id = carAdviceGrDictionarySender.Id }, carAdviceGrDictionarySender);
		//}


		//[HttpDelete("{id}")]
		//public async Task<IActionResult> DeleteCarAdviceGrDictionarySender(long id)
		//{
		//	if (_context.CarAdviceGrDictionarySender == null)
		//	{
		//		return NotFound();
		//	}
		//	var carAdviceGrDictionarySender = await _context.CarAdviceGrDictionarySender.FindAsync(id);
		//	if (carAdviceGrDictionarySender == null)
		//	{
		//		return NotFound();
		//	}
		//	try
		//	{
		//		_context.CarAdviceGrDictionarySender.Remove(carAdviceGrDictionarySender);
		//		await _context.SaveChangesAsync();
		//	}
		//	catch (DbUpdateException ex) 
		//	{

		//		return StatusCode(400, ex.Message);
		//	}
		//	return NoContent();
		//}


		//private bool carAdviceGrDictionarySenderExist(long id)
		//{
		//	return (_context.CarAdviceGrDictionarySender?.Any(e => e.Id == id)).GetValueOrDefault();
		//}

	}

      
     
    
    
}
