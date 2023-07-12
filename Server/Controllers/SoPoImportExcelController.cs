using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCMDWH.Server.Data;
using SCMDWH.Shared.DTO;
using SCMDWH.Shared.Models;

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoPoImportExcelController : ControllerBase
    {
        private readonly PurchasingContext _context;

        public SoPoImportExcelController(PurchasingContext context)
        {
            _context = context;
        }
        [HttpPost("ValidateSOPOExcel")]
        public async Task<ActionResult> ValidateSOPOExcel([FromBody] List<SoPoImportExcel> excelImportedList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TPVStockContext tPVStockContext = new TPVStockContext();
            List<Recipient> recipients = tPVStockContext.Recipients.Where(R => R.Sapid != "").ToList();
            List<Product> products = tPVStockContext.Products.ToList();
            List<ProductPallet> productPalletList = tPVStockContext.ProductPallets.Where(P => P.DefaultPallet).ToList();
            //Jak powstanie model SO Items to wczytać wszystkie
            foreach (SoPoImportExcel excelItem in excelImportedList)
            {
                //Walidować duplikaty (czy numer PO nie jest w bazie danych) jak jest to błąd
                excelItem.IsOk = true;
                excelItem.ValidationTestResults = "";
                if (excelItem.OrderNo.Trim() == string.Empty)
                {
                    excelItem.IsOk = false;
                    excelItem.ValidationTestResults += $"The OrderNo cannot be empty! ";
                }
                bool OrderNoTest = int.TryParse(excelItem.OrderNo.Trim(), out int OrderNoValue);
                if (!OrderNoTest)
                {
                    excelItem.IsOk = false;
                    excelItem.ValidationTestResults += $"The Order number must be a valid integer, The entered value is: {excelItem.OrderNo.Trim()}! ";
                }
                if (excelItem.Qty <= 0)
                {
                    excelItem.IsOk = false;
                    excelItem.ValidationTestResults += $"Product Order Qty must be non-negative and greater than 0. The current order quantity is: {excelItem.Qty}! ";
                }
                List<Recipient> TestReciptList = recipients.Where(R => R.Sapid == excelItem.DestinationSAPId.Trim()).ToList();
                if (!TestReciptList.Any())
                {
                    excelItem.IsOk = false;
                    excelItem.ValidationTestResults += $"DestinationSAPId: {excelItem.DestinationSAPId.Trim()} Not Exist in WMS DB! ";
                }
                if (TestReciptList.Count() > 1)
                {
                    excelItem.IsOk = false;
                    excelItem.ValidationTestResults += $"There is more than one entry for the same DestinationSAPId: {excelItem.DestinationSAPId.Trim()} - {TestReciptList.Count()} items with same SAP ID, Please maintain the data in the database!, ";
                }
                List<Product> TestProductsList = products.Where(P => P.ProductCode == excelItem.Product.Trim()).ToList();
                if (!TestProductsList.Any())
                {
                    excelItem.IsOk = false;
                    excelItem.ValidationTestResults += $"Product: {excelItem.Product.Trim()} Not Exist in WMS DB! ";
                }
                bool DefaultPalletFound = false;
                foreach (Product product in TestProductsList)
                {
                    ProductPallet productPallet = productPalletList.FirstOrDefault(Pp => Pp.SkdpartNo == product.SkdpartNo.Trim());
                    if (productPallet != null)
                    {
                        DefaultPalletFound = true;
                        break;
                    }
                }
                if (!DefaultPalletFound)
                {
                    excelItem.IsOk = false;
                    excelItem.ValidationTestResults += $"Product: {excelItem.Product.Trim()} Default Pallet Not Found, Please maintain the data in the database! ";
                }
                if (excelItem.WkNo.Trim() == string.Empty)
                {
                    excelItem.IsOk = false;
                    excelItem.ValidationTestResults += $"The week number (WkNo) cannot be empty! ";
                }
                bool WkTest = int.TryParse(excelItem.WkNo.Trim(), out int WkNumber);
                if (WkTest)
                {
                    if (WkNumber < 1 || WkNumber > 53)
                    {
                        excelItem.IsOk = false;
                        excelItem.ValidationTestResults += $"The week number must be a value between 1 and 53, The entered value is: {excelItem.WkNo.Trim()}! ";
                    }
                }
                else
                {
                    excelItem.IsOk = false;
                    excelItem.ValidationTestResults += $"The week number must be a valid integer, The entered value is: {excelItem.WkNo.Trim()}! ";
                }
                if(excelItem.IsOk)
                {
                    excelItem.ValidationTestResults += "All validation tests passed.";
                }
            }
            return Ok(excelImportedList);
        }





        [HttpPost("UploadSOPOExcel")]
        public async Task<ActionResult> UploadSOPOExcel([FromBody] List<SoPoImportExcel> excelImportedList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            foreach (SoPoImportExcel excelItem in excelImportedList)
            {
                excelItem.IsOk = true;
                excelItem.ValidationTestResults = "Database Insert OK";
            }
            return Ok(excelImportedList);
        }
    }
}
