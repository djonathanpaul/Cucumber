using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NumberToWordService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CucumberWebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NumberToWordController : ControllerBase
    {
        private readonly INumberToWordConverter _numberToWordService;

        public NumberToWordController(INumberToWordConverter numberToWordService)
        {
            _numberToWordService = numberToWordService;
        }
        [HttpGet]
        public IActionResult Get(decimal amount)
        {
            AmountDataResponse ad = new AmountDataResponse();
            try
            {
                
                ad.amountLiteral = _numberToWordService.GenerateLiteralForAmount(amount);
                return Ok(ad);

            }
            catch(Exception)
            {
                ad.amountLiteral = string.Empty;
                ad.errorMsg = "Please enter an integer or decimal value in the Number field which is less than 2147483648.";
                return BadRequest(ad);

            }
            

        }
    }
}
