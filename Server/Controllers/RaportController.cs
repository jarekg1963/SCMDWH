using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCMDWH.Server.Sevices;

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaportController : ControllerBase
    {
        private ExportToExcel _serviceExcelReport;

        public RaportController (ExportToExcel serviceExcelReport)
        {
            _serviceExcelReport = serviceExcelReport;
        }

        [HttpGet("ReportToExcel/{UserName}")]

        public IActionResult DownloadAuthorsExport(string UserName)
        {

            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "ReportFromCarAdvice.xlsx";

            return File(_serviceExcelReport.CreateExcelExport(UserName), contentType, fileName);
        }

    }
}
