using System.Data.SQLite;
using System.Data;
using Helper_Layer;

namespace Data_Access_Layer
{
    public static class FeeSettingsDAL
    {
        public static long GetOpiningAccountFees()
        {

            SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection);

            string Query = @" SELECT OpiningAccountFees FROM FeeSettings";

            SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection);
            cmd.CommandType = CommandType.Text;

            long Result = -1;

            try
            {

                SQLiteConnection.Open();

                Result = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch
            {

                return Result;

            }
            finally
            {

                SQLiteConnection.Close();

            }

            return Result;

        }
        public static long UpdateOpiningAccountFees(long NewValue)
        {

            SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection);

            string Query = @"UPDATE FeeSettings
                                 SET OpiningAccountFees = @NewValue;";

            SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@NewValue", NewValue);

            try
            {

                SQLiteConnection.Open();

                return Convert.ToByte(cmd.ExecuteNonQuery());

            }
            catch
            {

                return 0;

            }
            finally
            {

                SQLiteConnection.Close();

            }

        }

        public static long GetVisaMonthlyCharge()
        {

            SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection);

            string Query = @"SELECT VisaMonthlyCharge FROM FeeSettings";

            SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection);
            cmd.CommandType = CommandType.Text;

            long Result = -1;

            try
            {

                SQLiteConnection.Open();

                Result = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch
            {

                return Result;

            }
            finally
            {

                SQLiteConnection.Close();

            }

            return Result;

        }
        public static long UpdateVisaMonthlyCharge(long NewValue)
        {

            SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection);

            string Query = @"UPDATE FeeSettings
                                SET VisaMonthlyCharge = @NewValue;";

            SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@NewValue", NewValue);

            try
            {

                SQLiteConnection.Open();

                return Convert.ToByte(cmd.ExecuteNonQuery());

            }
            catch
            {

                return 0;

            }
            finally
            {

                SQLiteConnection.Close();

            }

        }

        public static float GetCurrencyExchangePercentage()
        {

            SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection);

            string Query = @"SELECT CurrencyExchangePercentage FROM FeeSettings
";

            SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection);
            cmd.CommandType = CommandType.Text;

            float Result = -1;

            try
            {

                SQLiteConnection.Open();

                Result = Convert.ToSingle(cmd.ExecuteScalar());

            }
            catch
            {

                return Result;

            }
            finally
            {

                SQLiteConnection.Close();

            }

            return Result;

        }
        public static long UpdateCurrencyExchangePercentage(float NewValue)
        {

            SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection);

            string Query = @"UPDATE FeeSettings
                                 SET CurrencyExchangePercentage = @NewValue;";

            SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@NewValue", NewValue);

            try
            {

                SQLiteConnection.Open();

                return Convert.ToByte(cmd.ExecuteNonQuery());

            }
            catch
            {

                return 0;

            }
            finally
            {

                SQLiteConnection.Close();

            }

        }

        public static long GetApplicationFees()
        {

            SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection);

            string Query = @"SELECT ApplicationFees FROM FeeSettings";

            SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection);
            cmd.CommandType = CommandType.Text;

            long Result = -1;

            try
            {

                SQLiteConnection.Open();

                Result = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch
            {

                return Result;

            }
            finally
            {

                SQLiteConnection.Close();

            }

            return Result;

        }
        public static long UpdateApplicationFees(long NewValue)
        {

            SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection);

            string Query = @"UPDATE FeeSettings
                                SET ApplicationFees = @NewValue;";

            SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@NewValue", NewValue);

            try
            {

                SQLiteConnection.Open();

                return Convert.ToByte(cmd.ExecuteNonQuery());

            }
            catch
            {

                return 0;

            }
            finally
            {

                SQLiteConnection.Close();

            }

        }

    }
}

