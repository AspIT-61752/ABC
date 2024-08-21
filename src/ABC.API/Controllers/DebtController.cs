using Microsoft.AspNetCore.Mvc;

namespace ABC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtController : Controller
    {
        private readonly Calculator.Debt _calcD;
        private readonly Calculator.Math _calcM;

        public DebtController(Calculator.Debt calcD, Calculator.Math calcM)
        {
            _calcD = calcD;
            _calcM = calcM;
        }

        [HttpPost]
        [Route("PaybackDebtByMonthlyAmount")]
        public IActionResult PaybackDebtByMonthlyAmount(double debt, double interestRate, double amount)
        {
            string res = "";

            int paybackIn = _calcD.PaybackDebtByMonthlyAmount(debt, interestRate, amount);

            (int, int) paybackPipe = _calcM.MonthToYear(paybackIn);

            return Ok(paybackPipe);
        }


    }
}
