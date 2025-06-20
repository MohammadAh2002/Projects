using DTO_Layer;
using System.Data.SQLite;
using System.Data;
using Helper_Layer;

namespace Data_Access_Layer
{
    public static class CurrencyDAL
    {

        public static CurrencyDTO? GetCurrencyByName(string CurrencyName)
        {

            SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection);

            string Query = @"SELECT CurrencyName, CurrencyCode, ExchangeRate FROM Currencies
	                            WHERE CurrencyName LIKE @Name";

            SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@Name", CurrencyName);

            try
            {

                SQLiteConnection.Open();

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        return new CurrencyDTO(

                            reader.GetString(reader.GetOrdinal("CurrencyName")),
                            reader.GetString(reader.GetOrdinal("CurrencyCode")),
                            reader.GetDecimal(reader.GetOrdinal("ExchangeRate"))

                        );

                    }
                }

            }
            catch
            {

                return null;

            }
            finally
            {

                SQLiteConnection.Close();

            }
            return null;
        }    
        public static CurrencyDTO? GetCurrencyByCode(string CurrencyCode)
        {

            SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection);

            string Query = @" SELECT CurrencyName, CurrencyCode, ExchangeRate FROM Currencies
	                                WHERE CurrencyCode LIKE @Code;";

            SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@Code", CurrencyCode);

            try
            {

                SQLiteConnection.Open();

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        return new CurrencyDTO(

                            reader.GetString(reader.GetOrdinal("CurrencyName")),
                            reader.GetString(reader.GetOrdinal("CurrencyCode")),
                            reader.GetDecimal(reader.GetOrdinal("ExchangeRate"))

                        );

                    }
                }

            }
            catch
            {

                return null;

            }
            finally
            {

                SQLiteConnection.Close();

            }
            return null;

        }
        public static CurrencyDTO? GetCurrencyByExchangeRate(decimal ExchangeRate)
        {

            SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection);

            string Query = @"SELECT CurrencyName, CurrencyCode, ExchangeRate FROM Currencies
	                                WHERE ExchangeRate = @ExchangeRate";

            SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@ExchangeRate", ExchangeRate);

            try
            {

                SQLiteConnection.Open();

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        return new CurrencyDTO(

                            reader.GetString(reader.GetOrdinal("CurrencyName")),
                            reader.GetString(reader.GetOrdinal("CurrencyCode")),
                            reader.GetDecimal(reader.GetOrdinal("ExchangeRate"))

                        );

                    }

                }
            }
            catch
            {

                return null;

            }
            finally
            {

                SQLiteConnection.Close();

            }
            return null;

        }

        public static decimal GetExchangeRateByName(string CurrencyName)
        {

            SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection);

            string Query = @" SELECT ExchangeRate FROM Currencies 
						            WHERE CurrencyName LIKE @Name";

            SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@Name", CurrencyName);

            try
            {

                SQLiteConnection.Open();

                return Convert.ToDecimal(cmd.ExecuteScalar());

            }
            catch
            {

                return -1;

            }
            finally
            {

                SQLiteConnection.Close();

            }

        }
        public static decimal GetExchangeRateByCode(string CurrencyCode)
        {

            SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection);

            string Query = @"SELECT ExchangeRate FROM Currencies 
						           WHERE CurrencyCode LIKE @Code";

            SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@Code", CurrencyCode);

            try
            {

                SQLiteConnection.Open();

                return Convert.ToDecimal(cmd.ExecuteScalar());


            }
            catch
            {

                return -1;

            }
            finally
            {

                SQLiteConnection.Close();

            }

        }

        public static List<CurrencyDTO>? GetAllCurrencies()
        {

            SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection);

            string Query = @"SELECT CurrencyName, CurrencyCode, ExchangeRate FROM Currencies ";

            SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection);
            cmd.CommandType = CommandType.Text;

            List<CurrencyDTO> Currencies = new List<CurrencyDTO>();

            try
            {

                SQLiteConnection.Open();

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {

                        Currencies.Add(new CurrencyDTO(

                            reader.GetString(reader.GetOrdinal("CurrencyName")),
                            reader.GetString(reader.GetOrdinal("CurrencyCode")),
                            reader.GetDecimal(reader.GetOrdinal("ExchangeRate"))

                        ));

                    }
                }

                return Currencies;

            }
            catch
            {

                return null;

            }
            finally
            {

                SQLiteConnection.Close();

            }

        }

        public static stExchangeRateDetails? ExchangeRateDetails()
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection)) {

                string Query = @"SELECT
                                    COUNT(ID) AS NumberOfCurrencies,
                                    MAX(ExchangeRate) AS HighestExchangeRate,
                                    MIN(ExchangeRate) AS LowestExchangeRate,
                                    AVG(ExchangeRate) AS AverageExchangeRate
                                FROM Currencies";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read()) {

                            stExchangeRateDetails ExchangeRateDetails = new stExchangeRateDetails
                            {
                                NumberOfCurrencies = reader.GetInt64(reader.GetOrdinal("NumberOfCurrencies")),
                                HighestExchangeRate = reader.GetDecimal(reader.GetOrdinal("HighestExchangeRate")),
                                LowestExchangeRate = reader.GetDecimal(reader.GetOrdinal("LowestExchangeRate")),
                                AverageExchangeRate = reader.GetDecimal(reader.GetOrdinal("AverageExchangeRate"))

                            };

                            return ExchangeRateDetails;
                        }

                    }

                }
            
            
            
            }           
            
            return null;
        
        }

        public static long UpdateExchangeRateByName(CurrencyUpdateByNameDTO CurrencyDTO)
        {

            SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection);

            string Query = @"UPDATE Currencies
		                        SET ExchangeRate = @NewValue
			                        where CurrencyName = @Name;";

            SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@Name", CurrencyDTO.CurrencyName);
            cmd.Parameters.AddWithValue("@NewValue", CurrencyDTO.ExchangeRate);

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
        public static long UpdateExchangeRateByCode(CurrencyUpdateByCodeDTO CurrencyDTO)
        {

            SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection);

            string Query = @"UPDATE Currencies
                             SET ExchangeRate = @NewValue
	                                where CurrencyCode = @Code;";

            SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@Code", CurrencyDTO.CurrencyCode);
            cmd.Parameters.AddWithValue("@NewValue", CurrencyDTO.ExchangeRate);

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

        public static long DeleteCurrencyByName(string CurrencyName)
        {

            SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection);

            string Query = @"DELETE FROM Currencies 
		                        WHERE CurrencyName Like @Name;";

            SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@Name", CurrencyName);

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
        public static long DeleteCurrencyByCode(string CurrencyCode)
        {

            SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection);

            string Query = @"DELETE FROM Currencies 
		                        WHERE CurrencyCode Like @Code;";

            SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@Code", CurrencyCode);

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

        public static bool IsExistByCode(string CurrencyCode)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"SELECT 1
		                            FROM Currencies
			                            WHERE CurrencyCode Like @CurrencyCode";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@CurrencyCode", CurrencyCode);

                    SQLiteConnection.Open();

                    object Result = cmd.ExecuteScalar();

                    return Result != null;

                }
            }
        }
        public static bool IsExistByName(string CurrencyName)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"SELECT 1
		                            FROM Currencies
			                            WHERE CurrencyName Like @CurrencyName";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@CurrencyName", CurrencyName);

                    SQLiteConnection.Open();

                    object Result = cmd.ExecuteScalar();

                    return Result != null;

                }
            }
        }
        public static long AddCurrency(CurrencyDTO CDTO)
        {

            SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection);

            string Query = @"INSERT INTO Currencies(CurrencyName, CurrencyCode, ExchangeRate)
	                            VALUES (@Name, @Code, @ExchangeRate);";

            SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@Name", CDTO.CurrencyName);
            cmd.Parameters.AddWithValue("@Code", CDTO.CurrencyCode);
            cmd.Parameters.AddWithValue("@ExchangeRate", CDTO.ExchangeRate);

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
