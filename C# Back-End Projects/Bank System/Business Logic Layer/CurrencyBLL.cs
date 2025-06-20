using Data_Access_Layer;
using DTO_Layer;

namespace Business_Logic_Layer
{
    public class CurrencyBLL
    {
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }

        public CurrencyBLL(CurrencyDTO CDTO)
        {
            CurrencyName = CDTO.CurrencyName;
            CurrencyCode = CDTO.CurrencyCode;
            ExchangeRate = Math.Round(CDTO.ExchangeRate,2);
        }

        public CurrencyDTO CDTO
        {
            get
            {
                return new CurrencyDTO(
                        this.CurrencyName, this.CurrencyCode, this.ExchangeRate);
            }
        }

        public static CurrencyDTO? GetCurrencyByName(string CurrencyName)
        {

            if (CurrencyName.Length > 25 || CurrencyName.Length == 0)
                return null;

            return CurrencyDAL.GetCurrencyByName(CurrencyName);

        }
        public static CurrencyDTO? GetCurrencyByCode(string CurrencyCode)
        {

            if (CurrencyCode.Length > 3 || CurrencyCode.Length == 0)
                return null;

            return CurrencyDAL.GetCurrencyByCode(CurrencyCode);

        }
        public static CurrencyDTO? GetCurrencyByExchangeRate(decimal ExchangeRate)
        {

            if (ExchangeRate <= 0)
                return null;

            return CurrencyDAL.GetCurrencyByExchangeRate(ExchangeRate);

        }

        public static decimal GetExchangeRateByName(string CurrencyName)
        {

            if (CurrencyName.Length > 25 || CurrencyName.Length == 0)
                return -1;

            return CurrencyDAL.GetExchangeRateByName(CurrencyName);

        }
        public static decimal GetExchangeRateByCode(string CurrencyCode)
        {
            if (CurrencyCode.Length > 3 || CurrencyCode.Length == 0)
                return -1;

            return CurrencyDAL.GetExchangeRateByCode(CurrencyCode);

        }

        public static List<CurrencyDTO>? GetAllcurrencies()
        {

            return CurrencyDAL.GetAllCurrencies();

        }

        public static bool UpdateExchangeRateByName(CurrencyUpdateByNameDTO CurrencyDTO)
        {
            if (string.IsNullOrEmpty(CurrencyDTO.CurrencyName) || CurrencyDTO.CurrencyName.Length > 25)
                return false;

            return CurrencyDAL.UpdateExchangeRateByName(CurrencyDTO) > 0;

        }

        public static bool UpdateExchangeRateByCode(CurrencyUpdateByCodeDTO CurrencyDTO)
        {

            if (string.IsNullOrEmpty(CurrencyDTO.CurrencyCode) || CurrencyDTO.CurrencyCode.Length > 3)
                return false;

            return CurrencyDAL.UpdateExchangeRateByCode(CurrencyDTO) > 0;

        }

        public bool AddCurrency()
        {

            return CurrencyDAL.AddCurrency(CDTO) > 0;

        }

        public static bool DeleteCurrencyByName(string CurrencyName)
        {
            return CurrencyDAL.DeleteCurrencyByName(CurrencyName) > 0;
        }

        public static bool DeleteCurrencyByCode(string CurrencyCode)
        {
            return CurrencyDAL.DeleteCurrencyByCode(CurrencyCode) > 0;
        }

        public bool ValidateCurrencyData()
        {

            if (string.IsNullOrEmpty(CurrencyName) || CurrencyName.Length > 25 ||
                string.IsNullOrEmpty(CurrencyCode) || CurrencyCode.Length > 3 ||
                ExchangeRate <= 0)
                return false;

            return true;

        }

        public static decimal ConvertCurrency(long Amount, string CurrencyFrom, string CurrencyTo)
        {

            decimal AmountInUSD = Amount / CurrencyDAL.GetExchangeRateByCode(CurrencyFrom);
            decimal ConvertedAmount = AmountInUSD * CurrencyDAL.GetExchangeRateByCode(CurrencyTo);

            return Math.Round(ConvertedAmount, 2) ;

        }

        public static bool IsExistByCode(string CurrencyCode)
        {
            return CurrencyDAL.IsExistByCode(CurrencyCode);
        }

        public static bool IsExistByName(string CurrencyName)
        {
            return CurrencyDAL.IsExistByName(CurrencyName);
        }

        public static stExchangeRateDetails? ExchangeRateDetails()
        {

            return CurrencyDAL.ExchangeRateDetails();

        }

    }
}
