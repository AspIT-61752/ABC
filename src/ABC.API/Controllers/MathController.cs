using Microsoft.AspNetCore.Mvc;

namespace ABC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : Controller
    {
        // DI (Dependency Injection)
        // I used the article bellow to pick a Transient 
        // https://medium.com/@susithapb/understanding-singleton-scoped-and-transient-in-net-core-b7efede6c513 
        private readonly Calculator.Math _calc;

        public MathController(Calculator.Math calc)
        {
            _calc = calc;

            // If that doesn't work use this:
            //_calc = new Calculator.Math();
        }

        // TODO: Do we use [FromBody] or [FromQuery] 

        [HttpPost]
        [Route("SumOf")]
        public IActionResult SumOf(List<double> list)
        {
            if (list == null || list.Count == 0)
            {
                return BadRequest("A list of numbers is required.");
            }

            var res = _calc.SumOf(list);

            return Ok(res);
        }

        [HttpPost]
        [Route("Subtract")]
        public IActionResult Subtract(double a, double b)
        {
            var res = _calc.Subtract(a, b);

            return Ok(res);
        }

        [HttpPost]
        [Route("SubtractWithList")]
        public IActionResult SubtractWithList(double input, List<double> list)
        {
            if (list == null || list.Count == 0)
            {
                return BadRequest("A list of numbers is required.");
            }

            var res = _calc.SubtractWithList(input, list);

            return Ok(res);
        }
    }
}
