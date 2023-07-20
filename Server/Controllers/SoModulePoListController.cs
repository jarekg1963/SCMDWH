using DocumentFormat.OpenXml.Office.CustomUI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCMDWH.Server.Data;
using SCMDWH.Shared.DTO;
using SCMDWH.Shared.Models;

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoModulePoListController : Controller
    {
        private readonly PurchasingContext _context;
        private readonly TPVStockContext tPVStockContext;

        public SoModulePoListController(PurchasingContext context, TPVStockContext ctPVStockContext)
        {
            _context = context;
            tPVStockContext = ctPVStockContext;
        }


        // GET: all PO PR So lisy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoModulePoList>>> GetSoModulePoList()
        {
            if (_context.SoModulePoList == null)
            {
                return NotFound();
            }
            return await _context.SoModulePoList.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<SoModulePoList>> SoModulePoList(SoModulePoList soModulePoList)
        {
            if (_context.SoModulePoList == null)
            {
                return Problem("Entity set 'SoModulePoList'  is null.");
            }
            _context.SoModulePoList.Add(soModulePoList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("SoModulePoList", new { id = soModulePoList.Id }, soModulePoList);
        }

        [HttpPost("ValidateSoModulePoList")]
        public async Task<ActionResult> ValidateSOPOExcel([FromBody] List<SoModulePoList> ListSoModulePoList)
        {
            if (_context.SoModulePoList == null)
            {
                return Problem("Entity set 'SoModulePoList'  is null.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<Recipient> recipients = tPVStockContext.Recipients.Where(R => R.Sapid != "").ToList();
            List<Product> products = tPVStockContext.Products.ToList();
            List<ProductPallet> productPalletList = tPVStockContext.ProductPallets.Where(P => P.DefaultPallet).ToList();
            foreach (SoModulePoList SoModulePoListItem in ListSoModulePoList)
            {
                bool BaseIsCevaPo = SoModulePoListItem.IsCevaPo;
                string BaseRemark = SoModulePoListItem.Remark;
                string BaseCountry = SoModulePoListItem.DestinationCountryCode;
                string BaseDestynationName = SoModulePoListItem.DestinationName;
                bool IsOk = true;
                SoModulePoListItem.Remark = "";
                if (SoModulePoListItem.Reference.Trim() == string.Empty)
                {
                    IsOk = false;
                    SoModulePoListItem.Remark += $"The Reference cannot be empty! ";
                }
                bool OrderNoTest = long.TryParse(SoModulePoListItem.OrderNo.Trim(), out long OrderNoValue);
                //if (!OrderNoTest)
                //{
                //    IsOk = false;
                //    SoModulePoListItem.Remark += $"The Order number must be a valid integer, The entered value is: {SoModulePoListItem.Reference.Trim()}! ";
                //}
                if (SoModulePoListItem.Qty <= 0)
                {
                    IsOk = false;
                    SoModulePoListItem.Remark += $"Product Order Qty must be non-negative and greater than 0. The current order quantity is: {SoModulePoListItem.Qty}! ";
                }
                List<Recipient> TestReciptList = recipients.Where(R => R.Sapid == SoModulePoListItem.DestinationSapid.Trim()).ToList();
                if (!TestReciptList.Any())
                {
                    IsOk = false;
                    SoModulePoListItem.Remark += $"DestinationSAPId: {SoModulePoListItem.DestinationSapid.Trim()} Not Exist in WMS DB! ";
                }
                if (TestReciptList.Count() == 1)
                {
                    Recipient recipient = TestReciptList[0];
                    SoModulePoListItem.DestinationCountryCode = recipient.Country;
                    SoModulePoListItem.DestinationName = recipient.Name;
                    SoModulePoListItem.IsCevaPo = recipient.Sapid.Equals("0005010290");
                }
                if (TestReciptList.Count() > 1)
                {
                    IsOk = false;
                    SoModulePoListItem.Remark += $"There is more than one entry for the same DestinationSAPId: {SoModulePoListItem.DestinationSapid.Trim()} - {TestReciptList.Count()} items with same SAP ID, Please maintain the data in the database!, ";
                }
                List<Product> TestProductsList = products.Where(P => P.ProductCode == SoModulePoListItem.Product.Trim().PadRight(30, ' ')).ToList();
                if (!TestProductsList.Any())
                {
                    IsOk = false;
                    SoModulePoListItem.Remark += $"Product: {SoModulePoListItem.Product.Trim()} Not Exist in WMS DB! ";
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
                    IsOk = false;
                    SoModulePoListItem.Remark += $"Product: {SoModulePoListItem.Product.Trim()} Default Pallet Not Found, Please maintain the data in the database! ";
                }
                if (SoModulePoListItem.WkNo < 1 || SoModulePoListItem.WkNo > 53)
                {
                    IsOk = false;
                    SoModulePoListItem.Remark += $"The week number must be a value between 1 and 53, The entered value is: {SoModulePoListItem.WkNo}! ";
                }
                if (IsOk)
                {
                    SoModulePoListItem.Remark += "All validation tests passed.";
                }
                if (BaseRemark != SoModulePoListItem.Remark || BaseIsCevaPo != SoModulePoListItem.IsCevaPo || BaseCountry != SoModulePoListItem.DestinationCountryCode || BaseDestynationName !=  SoModulePoListItem.DestinationName)
                {
                    _context.Entry(SoModulePoListItem).State = EntityState.Modified;
                }
            }
            await _context.SaveChangesAsync();
            return Ok(ListSoModulePoList);
        }

        // GET: api/SoModulePoList/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SoModulePoList>> GetSoModulePoList(long id)
        {
            if (_context.SoModulePoList == null)
            {
                return NotFound();
            }
            var soModulePoList = await _context.SoModulePoList.FindAsync(id);

            if (soModulePoList == null)
            {
                return NotFound();
            }

            return soModulePoList;
        }



        // PUT: api/SoModulePoList/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoModulePoList(long id, SoModulePoList soModulePoList)
        {
            if (id != soModulePoList.Id)
            {
                return BadRequest();
            }

            _context.Entry(soModulePoList).State = EntityState.Modified;

          
                await _context.SaveChangesAsync();
           

            return NoContent();
        }


        // DELETE: api/SoModulePoList/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoModulePoList(long id)
        {
            if (_context.SoModulePoList == null)
            {
                return NotFound();
            }
            var soModulePoList = await _context.SoModulePoList.FindAsync(id);
            if (soModulePoList == null)
            {
                return NotFound();
            }

            _context.SoModulePoList.Remove(soModulePoList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
