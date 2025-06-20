using Data_Access_Layer;

namespace Business_Logic_Layer
{
    public static class FeeSettingsBLL
    {
        public static long GetOpiningAccountFees()
        {

            return FeeSettingsDAL.GetOpiningAccountFees();

        }
        public static bool UpdateOpiningAccountFees(long NewValue)
        {

            return FeeSettingsDAL.UpdateOpiningAccountFees(NewValue) > 0;

        }

        public static long GetVisaMonthlyCharge()
        {

            return FeeSettingsDAL.GetVisaMonthlyCharge();

        }
        public static bool UpdateVisaMonthlyCharge(long NewValue)
        {

            return FeeSettingsDAL.UpdateVisaMonthlyCharge(NewValue) > 0;

        }

        public static float GetCurrencyExchangePercentage()
        {

            return FeeSettingsDAL.GetCurrencyExchangePercentage();

        }
        public static bool UpdateCurrencyExchangePercentage(float NewValue)
        {

            return FeeSettingsDAL.UpdateCurrencyExchangePercentage(NewValue) > 0;

        }

        public static long GetApplicationFees()
        {

            return FeeSettingsDAL.GetApplicationFees();

        }
        public static bool UpdateApplicationFees(long NewValue)
        {

            return FeeSettingsDAL.UpdateApplicationFees(NewValue) > 0;

        }

    }
}
