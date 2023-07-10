using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCMDWH.Server.Data;
using SCMDWH.Shared.DTO;

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SOPoListController : ControllerBase
    {
        private readonly PurchasingContext _context;

        public SOPoListController(PurchasingContext context)
        {
            _context = context;
        }
        [HttpPost("ImportSOPOExcel")]
        public async Task<ActionResult> ImportSOPOExcel([FromBody] List<SoPoImportExcel> excelImportedList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(excelImportedList);
        }

        }
}
