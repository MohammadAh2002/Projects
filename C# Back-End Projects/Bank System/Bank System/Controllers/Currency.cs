using Business_Logic_Layer;
using DTO_Layer;
using Helper_Layer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Layer.Controllers
{
    [Route("api/Currency")]
    [ApiController]
    [RequireLoggedInUser]
    [Produces("application/json")]
    public class Currency : ControllerBase
    {

        /// <summary>
        /// Find an existing Currency By Name.
        /// </summary>
        [HttpGet("GetCurrencyByName/{CurrencyName}", Name = "GetCurrencyByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CurrencyDTO> GetCurrencyByName(
               [StringLength(25, MinimumLength = 1, ErrorMessage = "Currency Name must be between 1 and 25 characters.")] string CurrencyName
            )
        {

            if (string.IsNullOrEmpty(CurrencyName) || CurrencyName.Length > 25)
                return BadRequest("Currency Name Cannot be Empty or More than 25 character");

            CurrencyDTO? CurrencyDTO = CurrencyBLL.GetCurrencyByName(CurrencyName);

            if (CurrencyDTO == null)
                return NotFound("Currency not Found");

            return Ok(CurrencyDTO);

        }

        /// <summary>
        /// Find an existing Currency By Code.
        /// </summary>
        [HttpGet("GetCurrencyByCode/{CurrencyCode}", Name = "GetCurrencyByCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CurrencyDTO> GetCurrencyByCode(
               [StringLength(3, MinimumLength = 1, ErrorMessage = "Currency Code must be between 1 and 3 characters.")] string CurrencyCode
            )
        {

            if (string.IsNullOrEmpty(CurrencyCode) || CurrencyCode.Length > 3)
                return BadRequest("Currency Code Cannot be Empty or More than 3 character");


            CurrencyDTO? CurrencyDTO = CurrencyBLL.GetCurrencyByCode(CurrencyCode);

            if (CurrencyDTO == null)
                return NotFound("Currency not Found");

            return Ok(CurrencyDTO);

        }

        /// <summary>
        /// Get Currency By Exchange Rate.
        /// </summary>
        [HttpGet("GetCurrencyByExchangeRate/{ExchangeRate:decimal}", Name = "GetCurrencyByExchangeRate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CurrencyDTO> GetCurrencyByExchangeRate(
               [Range(0.01, double.MaxValue, ErrorMessage = "Exchange Rate must be greater than 0")] decimal ExchangeRate
            )
        {

            if (ExchangeRate <= 0)
                return BadRequest("the Currency Exchange Rate is not Valid");

            CurrencyDTO? CurrencyDTO = CurrencyBLL.GetCurrencyByExchangeRate(ExchangeRate);

            if (CurrencyDTO == null)
                return NotFound("Currency not Found");

            return Ok(CurrencyDTO);

        }

        /// <summary>
        /// Get Currency Exchange Rate By Name.
        /// </summary>
        [HttpGet("GetExchangeRateByName/{CurrencyName}", Name = "GetExchangeRateByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<decimal> GetExchangeRateByName(
               [StringLength(25, MinimumLength = 1, ErrorMessage = "Currency Name must be between 1 and 25 characters.")] string CurrencyName
            )
        {

            if (string.IsNullOrEmpty(CurrencyName) || CurrencyName.Length > 25)
                return BadRequest("Currency Name Cannot be Empty or More than 25 character");

            if (!CurrencyBLL.IsExistByName(CurrencyName))
                return BadRequest("Currency Dose not Exist");

            decimal ExchangeRate = CurrencyBLL.GetExchangeRateByName(CurrencyName);

            if (ExchangeRate == -1)
                return NotFound("Currency not Found");

            return Ok(ExchangeRate);

        }

        /// <summary>
        /// Get Currency Exchange Rate By Code.
        /// </summary>
        [HttpGet("GetExchangeRateByCode/{CurrencyCode}", Name = "GetExchangeRateByCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<decimal> GetExchangeRateByCode(
            [StringLength(3, MinimumLength = 1, ErrorMessage = "Currency Code must be between 1 and 3 characters.")] string CurrencyCode
            )
        {

            if (string.IsNullOrEmpty(CurrencyCode) || CurrencyCode.Length > 3)
                return BadRequest("Currency Code Cannot be Empty or More than 3 character");

            if (!CurrencyBLL.IsExistByCode(CurrencyCode))
                return BadRequest("Currency Dose not Exist");

            decimal ExchangeRate = CurrencyBLL.GetExchangeRateByCode(CurrencyCode);

            if (ExchangeRate == -1)
                return NotFound("Currency not Found");

            return Ok(ExchangeRate);

        }

        /// <summary>
        /// Convert Currency to Another Currency.
        /// </summary>
        [HttpGet("ConvertCurrency/{Amount:long}/{FromCode}/{ToCode}", Name = "ConvertCurrency")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<decimal> ConvertCurrency(
              [DataType(DataType.Currency)] [Range(0, long.MaxValue, ErrorMessage = "Amount can't be less than 0")] long Amount,
              [StringLength(3, MinimumLength = 1, ErrorMessage = "From Currency Code must be between 1 and 3 characters.")] string FromCode,
              [StringLength(3, MinimumLength = 1, ErrorMessage = "To  Currency Code must be between 1 and 3 characters.")] string ToCode
              )
        {

            if (Amount < 0)
                return BadRequest("Amount Can't be Less than 0");

            if (string.IsNullOrEmpty(FromCode) || FromCode.Length > 3)
                return BadRequest("Currency Code Cannot be Empty or More than 3 character");

            if (string.IsNullOrEmpty(ToCode) || ToCode.Length > 3)
                return BadRequest("Currency Code Cannot be Empty or More than 3 character");

            if (!CurrencyBLL.IsExistByCode(FromCode))
                return BadRequest("From Currency Dose not Exist");

            if (!CurrencyBLL.IsExistByCode(ToCode))
                return BadRequest("To Currency Dose not Exist\"");

            decimal ExchangeRate = CurrencyBLL.ConvertCurrency(Amount, FromCode, ToCode);

            return Ok($"Converting {Amount} From {FromCode} to {ToCode} is: " + ExchangeRate);

        }

        /// <summary>
        /// Get All Currencies.
        /// </summary>
        [HttpGet("All", Name = "GetAllCurrencies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<CurrencyDTO>> GetAllcurrencies()
        {

            List<CurrencyDTO>? Currencies = CurrencyBLL.GetAllcurrencies();

            if (Currencies == null || Currencies.Count <= 0)
                return NotFound("no Currencies Found");

            return Ok(Currencies);

        }

        /// <summary>
        /// Update Exchange Rate By Name.
        /// </summary>
        [HttpPatch("UpdateExchangeRateByName", Name = "UpdateExchangeRateByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateExchangeRateByName([FromForm] CurrencyUpdateByNameDTO CurrencyDTO)
        {

            if (string.IsNullOrEmpty(CurrencyDTO.CurrencyName) || CurrencyDTO.CurrencyName.Length > 25)
                return BadRequest("Currency Name Cannot be Empty or More than 25 character");

            bool result = CurrencyBLL.UpdateExchangeRateByName(CurrencyDTO);

            if (!result)
                return NotFound("Faild to Update Currency");

            return Ok("Currency Update Successfullys");

        }

        /// <summary>
        /// Update Exchange Rate By Code.
        /// </summary>
        [HttpPatch("UpdateExchangeRateByCode", Name = "UpdateExchangeRateByCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateExchangeRateByCode([FromForm] CurrencyUpdateByCodeDTO CurrencyDTO)
        {

            if (string.IsNullOrEmpty(CurrencyDTO.CurrencyCode) || CurrencyDTO.CurrencyCode.Length > 3)
                return BadRequest("Currency Code Cannot be Empty or More than 3 character");

            bool result = CurrencyBLL.UpdateExchangeRateByCode(CurrencyDTO);

            if (!result)
                return NotFound("Faild to Update Currency");

            return Ok("Currency Update Successfullys");

        }

        /// <summary>
        /// Adds new Currency.
        /// </summary>
        [HttpPost("Add", Name = "AddCurrency")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddCurrency([FromForm] CurrencyDTO NewCurrencyDTO)
        {
            CurrencyBLL NewCurrency = new CurrencyBLL(NewCurrencyDTO);

            if (!NewCurrency.ValidateCurrencyData())
                return BadRequest("Currency Info is not Valid");

            bool Result = NewCurrency.AddCurrency();

            if (!Result)
                return NotFound("Faild to Add NewCurrency");

            return CreatedAtRoute("GetCurrencyByName", new { NewCurrencyDTO.CurrencyName }, NewCurrencyDTO);

        }

        /// <summary>
        /// Delete an Existing Currency By Name.
        /// </summary>
        [HttpDelete("DeleteCurrencyByName/{CurrencyName}", Name = "DeleteCurrencyByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteCurrencyByName(
               [StringLength(25, MinimumLength = 1, ErrorMessage = "Currency Name must be between 1 and 25 characters.")] string CurrencyName
            )
        {

            if (string.IsNullOrEmpty(CurrencyName) || CurrencyName.Length > 25)
                return BadRequest("Currency Name Cannot be Empty or More than 25 character");

            if (!CurrencyBLL.IsExistByName(CurrencyName))
                return BadRequest("Currency Dose not Exist");

            bool result = CurrencyBLL.DeleteCurrencyByName(CurrencyName);

            if (!result)
                return NotFound("Faild to Delete Currency");

            return Ok("Currency Deleted Successfullys");

        }


        /// <summary>
        /// Delete an Existing Currency By Code.
        /// </summary>
        [HttpDelete("DeleteCurrencyByCode/{CurrencyCode}", Name = "DeleteCurrencyByCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteCurrencyByCode(
               [StringLength(3, MinimumLength = 1, ErrorMessage = "Currency Code must be between 1 and 3 characters.")] string CurrencyCode
            )
        {

            if (string.IsNullOrEmpty(CurrencyCode) || CurrencyCode.Length > 3)
                return BadRequest("Currency Code Cannot be Empty or More than 3 character");

            if (!CurrencyBLL.IsExistByCode(CurrencyCode))
                return BadRequest("Currency Dose not Exist");

            bool result = CurrencyBLL.DeleteCurrencyByCode(CurrencyCode);

            if (!result)
                return NotFound("Faild to Delete Currency");

            return Ok("Currency Deleted Successfullys");

        }

        /// <summary>
        /// Check if an Currency Exists By Code.
        /// </summary>
        [HttpGet("IsExistByCode/{CurrencyCode}", Name = "IsCurrencyExistByCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult IsExistByCode(
               [StringLength(3, MinimumLength = 1, ErrorMessage = "Currency Code must be between 1 and 3 characters.")] string CurrencyCode
            )
        {

            if (string.IsNullOrEmpty(CurrencyCode) || CurrencyCode.Length > 3)
                return BadRequest("Code Cannot be Empty or More than 3 character");

            if (CurrencyBLL.IsExistByCode(CurrencyCode))
                return Ok(true);

            return NotFound(false);

        }

        /// <summary>
        /// Check if an Currency Exists By Name.
        /// </summary>
        [HttpGet("IsExistByName/{CurrencyName}", Name = "IsCurrencyExistByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult IsExistByName(
               [StringLength(25, MinimumLength = 1, ErrorMessage = "Currency Name must be between 1 and 25 characters.")] string CurrencyName
            )
        {

            if (string.IsNullOrEmpty(CurrencyName) || CurrencyName.Length > 25)
                return BadRequest("Name Cannot be Empty or More than 25 character");

            if (CurrencyBLL.IsExistByName(CurrencyName))
                return Ok(true);

            return NotFound(false);

        }

        /// <summary>
        /// Get Data About Exchange Rate.
        /// </summary>
        [HttpGet("ExchangeRateDetails", Name = "ExchangeRateDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<stExchangeRateDetails> ExchangeRateDetails()
        {

            stExchangeRateDetails? stExchangeRateDetails = CurrencyBLL.ExchangeRateDetails();

            if (stExchangeRateDetails == null)
                return NotFound("Failed to Get Data");

            return Ok(stExchangeRateDetails);

        }

    }
}
