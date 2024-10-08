﻿using Microsoft.AspNetCore.Mvc;

namespace ABC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtController : Controller
    {
        private readonly Calculator.DebtManager _calcD;
        private readonly Calculator.Math _calcM;

        public DebtController(Calculator.DebtManager calcD, Calculator.Math calcM)
        {
            _calcD = calcD;
            _calcM = calcM;
        }

        // TODO: Do we use [FromBody] or [FromQuery]
        [HttpPost]
        [Route("PaybackDebtByMonthlyAmount")]
        public IActionResult PaybackDebtByMonthlyAmount(double debt, double interestRate, double amount)
        {
            string res = "";

            int paybackIn = _calcD.PaybackDebtByInstallment_formula(debt, interestRate, amount);

            (int, int) paybackPipe = _calcM.MonthToYear(paybackIn);

            return Ok(paybackPipe);
        }


    }
}
