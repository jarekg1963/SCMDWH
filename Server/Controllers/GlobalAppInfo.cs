using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SCMDWH.Shared.Models;
using System.Globalization;

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalAppInfoController : ControllerBase
    {
        private readonly IOptions<GlobalAppInfo> _companyOptions;

        public GlobalAppInfoController(IOptions<GlobalAppInfo> companyOptions)
        {
            _companyOptions = companyOptions;
        }

        [HttpGet]
        public ActionResult<GlobalAppInfo> GetCompanyOptions()
        {
            var companyOptions = _companyOptions.Value;
            return Ok(companyOptions);
        }

    }
}
