using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCMDWH.Shared.Models;
using System.Net;
using System.Text.Json.Serialization;
using SCMDWH.Shared;
using SCMDWH.Client.Shared;
using NPOI.SS.Formula.Functions;
using System.ComponentModel;

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private readonly ILogger<TestController> _logger;


        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }


        [HttpGet("Throw")]
        public IActionResult Throw() =>
        //throw new Exception("Sample exception.");
        //throw new NotImplementedException();
        throw new BadHttpRequestException("Error not dedined in katrix ");



        [HttpGet]
        public async Task<ActionResult<List<Element>>> GetCarAdviceDictionaryCustomer()
        {
            throw new BadHttpRequestException("Error not dedined in katrix ");
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string APIURL = $"https://mudblazor.com/webapi/periodictable";
                    var response = await httpClient.GetAsync(APIURL);
                    return await response.Content.ReadFromJsonAsync<List<Element>>();
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return BadRequest(ex.Message);

            }

         

        }
    }

}




public class Element
{
    public string Group { get; set; }
    public int Position { get; set; }
    public string Name { get; set; }
    public int Number { get; set; }

    [JsonPropertyName("small")]
    public string Sign { get; set; }
    public double Molar { get; set; }
    public IList<int> Electrons { get; set; }

    public override string ToString()
    {
        return $"{Sign} - {Name}";
    }
}
