
using System.ComponentModel.DataAnnotations;

namespace DTO_Layer
{
    public class CurrencyDTO
    {

        [Required(ErrorMessage = "Currency Name is required.")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Currency Name must be between 2 and 50 characters.")]
        public string CurrencyName { get; set; }

        [Required(ErrorMessage = "Currency Code is required.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Currency Code must be Exactly 3 Characters")]
        public string CurrencyCode { get; set; }

        [Required(ErrorMessage = "Exchange Rate is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Exchange Rate must be a non-negative number.")]
        public decimal ExchangeRate { get; set; }

        public CurrencyDTO(string CurrencyName, string CurrencyCode, decimal ExchangeRate) {

            this.CurrencyName = CurrencyName;
            this.CurrencyCode = CurrencyCode;
            this.ExchangeRate = ExchangeRate;
        }

        public CurrencyDTO() { }

    }

    public class CurrencyUpdateByNameDTO
    {

        [Required(ErrorMessage = "Currency Name is required.")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Currency Name must be between 2 and 50 characters.")]
        public string CurrencyName { get; set; }

        [Required(ErrorMessage = "Exchange Rate is required.")]
        public decimal ExchangeRate { get; set; }

        public CurrencyUpdateByNameDTO(string CurrencyName, decimal ExchangeRate)
        {

            this.CurrencyName = CurrencyName;
            this.ExchangeRate = ExchangeRate;

        }

        public CurrencyUpdateByNameDTO() { }

    }

    public class CurrencyUpdateByCodeDTO
    {

        [Required(ErrorMessage = "Currency Code is required.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Currency Code must be between 2 and 50 characters.")]
        public string CurrencyCode { get; set; }

        [Required(ErrorMessage = "Exchange Rate is required.")]

        public decimal ExchangeRate { get; set; }

        public CurrencyUpdateByCodeDTO(string CurrencyCode, decimal ExchangeRate)
        {

            this.CurrencyCode = CurrencyCode;
            this.ExchangeRate = ExchangeRate;

        }
        public CurrencyUpdateByCodeDTO() { }

    }

    public struct stExchangeRateDetails
    {
    
        public long NumberOfCurrencies { get; set;}
        public decimal HighestExchangeRate { get; set;}
        public decimal LowestExchangeRate { get; set; }
        public decimal AverageExchangeRate { get; set; }

    }
}
