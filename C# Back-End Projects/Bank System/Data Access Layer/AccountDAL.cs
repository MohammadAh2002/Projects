using DTO_Layer;
using Helper_Layer;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Data_Access_Layer
{
    public static class AccountDAL
    {

        public static AccountDTO? Find(long ID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"
                                SELECT Balance, DateOpened, DateClosed,
                                        AccountStatusID, CustomerID
		                                                    From Accounts
			                                                     Where ID = @ID and AccountStatusID = 1;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", ID);

                    DateTime? DateClosed;

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            DateClosed = reader["DateClosed"] == DBNull.Value ?
                                            null : (DateTime?)Convert.ToDateTime(reader["DateClosed"]);

                            return new AccountDTO(
                                    ID,
                                    Convert.ToDecimal(reader["Balance"]),
                                    Convert.ToDateTime(reader["DateOpened"]),
                                    DateClosed,
                                    (long)reader["AccountStatusID"],
                                    (long)reader["CustomerID"]
                            );

                        }
                    }

                    return null;
                }

            }
        }

        public static long Add(AccountDTO AccountDTO)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"
                    Insert into Accounts(Balance, DateOpened, DateClosed, AccountStatusID, CustomerID)
	                        values (@Balance, @DateOpened, @DateClosed, @Status, @CustomerID);

                    SELECT last_insert_rowid();";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Balance", AccountDTO.Balance);
                    cmd.Parameters.AddWithValue("@DateOpened", AccountDTO.DateOpened);
                    cmd.Parameters.AddWithValue("@Status", AccountDTO.StatusID);
                    cmd.Parameters.AddWithValue("@CustomerID", AccountDTO.CustomerID);

                    if (AccountDTO.DateClosed == null)
                        cmd.Parameters.AddWithValue("@DateClosed", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@DateClosed", AccountDTO.DateClosed);

                    SQLiteConnection.Open();

                    object Result = cmd.ExecuteScalar();

                    return Convert.ToInt32(Result);

                }
            }
        }

        public static decimal AccountBalance(long ID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"
                                 SELECT Balance
		                                From Accounts
			                                Where ID = @ID;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", ID);

                    SQLiteConnection.Open();

                    object Result = cmd.ExecuteScalar();

                    if (Result != null)
                        return Convert.ToDecimal(Result);
                }

            }

            return -1;
        }
        public static bool Delete(long ID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"
                                DELETE FROM Accounts 
		                                WHERE ID = @ID;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", ID);

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        public static bool IsExist(long ID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"
                                SELECT 1
		                            FROM Accounts
			                            WHERE ID = @ID and AccountStatusID = 1;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", ID);

                    SQLiteConnection.Open();

                    object Result = cmd.ExecuteScalar();

                    return Result != null;

                }
            }
        }

        public static List<AccountShowDTO> GetAll()
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"Select * From VIEW_AllAccounts";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    List<AccountShowDTO> Accounts = new List<AccountShowDTO>();
                    DateTime? DateClosed;

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            DateClosed = reader["DateClosed"] == DBNull.Value ?
                                          null : (DateTime?)Convert.ToDateTime(reader["DateClosed"]);

                            long id = (long)reader["ID"];
                            decimal balance = Convert.ToDecimal(reader["Balance"]);
                            DateTime dateOpened = Convert.ToDateTime(reader["DateOpened"]);
                            long statusId = (long)reader["StatusID"];
                            string customerName = (string)reader["CustomerName"];

                            Accounts.Add(new AccountShowDTO(

                                    (long)reader["ID"],
                                    Convert.ToDecimal(reader["Balance"]),
                                    Convert.ToDateTime(reader["DateOpened"]),
                                    DateClosed,
                                    (long)reader["StatusID"],
                                    (string)reader["CustomerName"]

                            ));

                        }
                    }
                    return Accounts;
                }

            }
        }

        public static bool Open(long ID)
        {

            string Query = @"
	                        UPDATE Accounts
				                        SET
				                        AccountStatusID = @Status
					                        Where ID = @ID;";

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Status", 1);

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }

        }

        public static List<AccountShowDTO> CustomerAllAccounts(long CustomerID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"SELECT  * From VIEW_CustomerAllAccounts                           
                                    WHERE
                                         CustomerID = @CustomerID;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    List<AccountShowDTO> Accounts = new List<AccountShowDTO>();
                    DateTime? DateClosed;

                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            DateClosed = reader["DateClosed"] == DBNull.Value ?
                                          null : (DateTime?)Convert.ToDateTime(reader["DateClosed"]);

                            Accounts.Add(new AccountShowDTO(

                                    (long)reader["ID"],
                                    Convert.ToDecimal(reader["Balance"]),
                                    Convert.ToDateTime(reader["DateOpened"]),
                                    DateClosed,
                                    (long)reader["StatusID"],
                                    (string)reader["CustomerName"]

                            ));

                        }
                    }
                    return Accounts;
                }
            }

        }

        public static bool DeleteCustomerAllAccounts(long CustomerID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"
                                UPDATE Accounts
				                        SET
				                        AccountStatusID = 3,
				                        DateClosed = @DateClosed 
		                                WHERE CustomerID = @CustomerID;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    cmd.Parameters.AddWithValue("@DateClosed", DateTime.Now.ToString("yyyy-MM-dd"));

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }


        public static bool Close(long ID)
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"
                                 UPDATE Accounts
				                        SET
				                        AccountStatusID = @Status,
				                        DateClosed = @DateClosed
					                        Where ID = @ID;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Status", 3);
                    cmd.Parameters.AddWithValue("@DateClosed", DateTime.Now.ToString("yyyy-MM-dd"));

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }

        }
        public static bool IsClosed(long ID)
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"
                                SELECT 1
		                            FROM Accounts
			                            WHERE ID = @ID and AccountStatusID = 3;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", ID);

                    SQLiteConnection.Open();

                    object Result = cmd.ExecuteScalar();

                    return Result != null;

                }
            }

        }


        public static bool Suspend(long ID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"
                                UPDATE Accounts
				                SET
				                AccountStatusID = @Status
					                Where ID = @ID;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Status", 2);

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }
    }
}
