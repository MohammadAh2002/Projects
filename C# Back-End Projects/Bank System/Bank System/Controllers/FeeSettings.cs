using Business_Logic_Layer;
using Helper_Layer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Layer.Controllers
{
    [Route("api/FeeSettings")]
    [ApiController]
    [RequireLoggedInUser]
    [Produces("application/json")]
    public class FeeSettings : ControllerBase
    {

        /// <summary>
        /// Get the Current Opining Account Fees.
        /// </summary>
        [HttpGet("GetOpiningAccountFees", Name = "GetOpiningAccountFees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetOpiningAccountFees()
        {

            long Result = FeeSettingsBLL.GetOpiningAccountFees();

            if (Result == -1)
                return NotFound("Somthing Went Wrong");


            return Ok(Result);
        }

        /// <summary>
        /// Update Opining Account Fees.
        /// </summary>
        [HttpPut("UpdateOpiningAccountFees/{NewValue:long}", Name = "UpdateOpiningAccountFees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateOpiningAccountFees(
             [Range(0, long.MaxValue, ErrorMessage = "Account Fees can'y be Less than 0")] long NewValue
            )
        {

            if (NewValue < 0)
                return BadRequest("New Value Can't Be Less than 0");

            bool Result = FeeSettingsBLL.UpdateOpiningAccountFees(NewValue);

            if (!Result)
                return NotFound("Somthing Went Wrong Failed to Update");


            return Ok("Opining Account Fees New Value is :" + NewValue);
        }

        /// <summary>
        /// Get the Current Visa Monthly Charge.
        /// </summary>
        [HttpGet("GetVisaMonthlyCharge", Name = "GetVisaMonthlyCharge")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetVisaMonthlyCharge()
        {

            long Result = FeeSettingsBLL.GetVisaMonthlyCharge();

            if (Result == -1)
                return NotFound("Somthing Went Wrong");

            return Ok(Result);
        }

        /// <summary>
        /// Update Current Visa Monthly Charge.
        /// </summary>
        [HttpPut("UpdateVisaMonthlyCharge/{NewValue:long}", Name = "UpdateVisaMonthlyCharge")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateVisaMonthlyCharge(
            [Range(0, long.MaxValue, ErrorMessage = "Account Fees can'y be Less than 0")] long NewValue)
        {

            if (NewValue < 0)
                return BadRequest("New Value Can't Be Less than 0");

            bool Result = FeeSettingsBLL.UpdateVisaMonthlyCharge(NewValue);

            if (!Result)
                return NotFound("Somthing Went Wrong Failed to Update");

            return Ok("Visa Monthly Charge New Value is: " + NewValue);
        }

        /// <summary>
        /// Get the Current Currency Exchange Percentage.
        /// </summary>
        [HttpGet("GetCurrencyExchangePercentage", Name = "GetCurrencyExchangePercentage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetCurrencyExchangePercentage()
        {

            float Result = FeeSettingsBLL.GetCurrencyExchangePercentage();

            if (Result == -1)
                return NotFound("Somthing Went Wrong");

            return Ok(Result);

        }

        /// <summary>
        /// Update Current Currency Exchange Percentage.
        /// </summary>
        [HttpPut("UpdateCurrencyExchangePercentage/{NewValue:float}", Name = "UpdateCurrencyExchangePercentage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateCurrencyExchangePercentage(
             [Range(0, long.MaxValue, ErrorMessage = "Account Fees can'y be Less than 0")] float NewValue)
        {

            if (NewValue < 0)
                return BadRequest("New Value Can't Be Less than 0");

            bool Result = FeeSettingsBLL.UpdateCurrencyExchangePercentage(NewValue);

            if (!Result)
                return NotFound("Somthing Went Wrong Failed to Update");

            return Ok("Currency Exchange Percentage New Value is: " + NewValue);

        }

        /// <summary>
        /// Get the Current Application Fees.
        /// </summary>
        [HttpGet("GetApplicationFees", Name = "GetApplicationFees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetApplicationFees()
        {

            long Result = FeeSettingsBLL.GetApplicationFees();

            if (Result == -1)
                return NotFound("Somthing Went Wrong");

            return Ok(Result);

        }

        /// <summary>
        /// Update Current Application Fees.
        /// </summary>
        [HttpPut("UpdateApplicationFees/{NewValue:long}", Name = "UpdateApplicationFees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateApplicationFees(
           [Range(0, long.MaxValue, ErrorMessage = "Account Fees can'y be Less than 0")] long NewValue)
        {

            if (NewValue < 0)
                return BadRequest("New Value Can't Be Less than 0");

            bool Result = FeeSettingsBLL.UpdateApplicationFees(NewValue);

            if (!Result)
                return NotFound("Somthing Went Wrong Failed to Update");

            return Ok("Application Fees New Value is: " + NewValue);

        }

    }

}
