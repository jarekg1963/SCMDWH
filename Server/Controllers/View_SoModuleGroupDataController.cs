using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;
using Microsoft.EntityFrameworkCore;

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

	}
}
