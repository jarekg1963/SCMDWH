using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;
using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml.Office2010.Excel;
using SCMDWH.Shared.DTO;

namespace SCMDWH.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class View_SoModuleGroupDataController : ControllerBase
	{
		private readonly PurchasingContext _context;

		public View_SoModuleGroupDataController(PurchasingContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<View_SoModuleGroupData>>> GetView_SoModuleGroupData()
		{
			if (_context.View_SoModuleGroupDatas == null)
			{
				return NotFound();
			}
			return await _context.View_SoModuleGroupDatas.ToListAsync();
		}



		[HttpGet("{forFoundid}")]
		public async Task<ActionResult<View_SoModuleGroupData>> GetView_SoModuleGroupData(long forFoundid)
        {
            var ViewFouded = await _context.View_SoModuleGroupDatas.FirstOrDefaultAsync(c => c.Id == forFoundid);
			var truckId = ViewFouded.TruckId;

			if (ViewFouded == null)
			{
				return NotFound();
			}

			return Ok(ViewFouded);
		}


		[HttpPost] 
        [Route("UpdateColour")]
        public async Task<IActionResult> UpdateTruckColour([FromBody] ColorForTuck colorForTuck)
		{
            var ViewFouded = await _context.View_SoModuleGroupDatas.FirstOrDefaultAsync(c => c.Id == colorForTuck.truckId);

			long idTruck = (long)ViewFouded.TruckId;

			var truckForColourChange = await _context.SoModuleTruckList.FirstOrDefaultAsync(c => c.Id == idTruck);

			truckForColourChange.LineBgColorDefinedByUser = colorForTuck.truckColour;

            _context.Entry(truckForColourChange).State = EntityState.Modified;

            await _context.SaveChangesAsync();

			return Ok(ViewFouded);

        }


        }
}
