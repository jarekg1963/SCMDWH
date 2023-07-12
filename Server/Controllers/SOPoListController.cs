using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCMDWH.Server.Data;
using SCMDWH.Shared.DTO;
using SCMDWH.Shared.Models;

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
            TPVStockContext tPVStockContext = new TPVStockContext();
            List<Recipient> recipients = tPVStockContext.Recipients.Where(R => R.Sapid != "").ToList();
            List<Product> products = tPVStockContext.Products.ToList();
            foreach (SoPoImportExcel excelItem in excelImportedList)
            {
                if (excelItem.OrderNo.Trim() == string.Empty)
                {
                    excelItem.IsOk = false;
                    excelItem.ValidationTestResults = $"The OrderNo cannot be empty! ";
                }
                // I TU PYTANIE - Czy traktujemy te zlecenia jako pełnoprawne PO co mają być zgodne z SAP - czy też tam może być jakiś inny Syf - czy walidować wartości numeryczne czy olewać ???
                bool OrderNoTest = int.TryParse(excelItem.OrderNo.Trim(), out int OrderNoValue);
                if (!OrderNoTest)
                {
                    excelItem.IsOk = false;
                    excelItem.ValidationTestResults = $"The Order number must be a valid integer, The entered value is: {excelItem.OrderNo.Trim()}! ";
                }
                excelItem.IsOk = true;
                if (excelItem.Qty <= 0)
                {
                    excelItem.IsOk = false;
                    excelItem.ValidationTestResults = $"Product Order Qty must be non-negative and greater than 0. the current order quantity is: {excelItem.Qty}! ";
                }
                List<Recipient> TestReciptList = recipients.Where(R => R.Sapid == excelItem.DestinationSAPId.Trim()).ToList();
                if (!TestReciptList.Any())
                {
                    excelItem.IsOk = false;
                    excelItem.ValidationTestResults = $"DestinationSAPId: {excelItem.DestinationSAPId.Trim()} Not Exist in WMS DB! ";
                }
                if (TestReciptList.Count() > 1)
                {
                    excelItem.IsOk = false;
                    excelItem.ValidationTestResults = $"There is more than one entry for the same DestinationSAPId: {excelItem.DestinationSAPId.Trim()} - {TestReciptList.Count()} items with same SAP ID, Please maintain the data in the database!, ";
                }
                List<Product> TestProductsList = products.Where(P => P.ProductCode == excelItem.Product.Trim()).ToList();
                if (!TestProductsList.Any())
                {
                    excelItem.IsOk = false;
                    excelItem.ValidationTestResults = $"Product: {excelItem.Product.Trim()} Not Exist in WMS DB! ";
                }
                if (excelItem.WkNo.Trim() == string.Empty)
                {
                    excelItem.IsOk = false;
                    excelItem.ValidationTestResults = $"The week number (WkNo) cannot be empty! ";
                }
                bool WkTest = int.TryParse(excelItem.WkNo.Trim(), out int WkNumber);
                if (WkTest)
                {
                    if (WkNumber < 1 || WkNumber > 53)
                    {
                        excelItem.IsOk = false;
                        excelItem.ValidationTestResults = $"The week number must be a value between 1 and 53, The entered value is: {excelItem.WkNo.Trim()}! ";
                    }
                }
                else
                {
                    excelItem.IsOk = false;
                    excelItem.ValidationTestResults = $"The week number must be a valid integer, The entered value is: {excelItem.WkNo.Trim()}! ";
                }
                if(excelItem.IsOk)
                {
                    excelItem.ValidationTestResults = "All validation tests passed.";
                }
            }
            return Ok(excelImportedList);
        }
    }
}
