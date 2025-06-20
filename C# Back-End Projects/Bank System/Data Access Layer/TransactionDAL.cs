using DTO_Layer;
using Helper_Layer;
using System.Data.SQLite;
using System.Data;

namespace Data_Access_Layer
{
    public static class TransactionDAL
    {

        public static bool Withdrawal(long AccountID, decimal Amount)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {
                string Query = @"BEGIN TRANSACTION;

                                UPDATE Accounts
                                SET Balance = (Balance - @Amount)
                                WHERE ID = @AccountID AND AccountStatusID = 1; 

                                INSERT INTO Transactions (Amount, AccountID, TransactionTypeID, TransactionDate)
                                VALUES (@Amount, @AccountID, @TransactionType, @TransactionDate);

                                COMMIT;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@AccountID", AccountID);
                    cmd.Parameters.AddWithValue("@Amount", Amount);
                    cmd.Parameters.AddWithValue("@TransactionType", 2);
                    cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }



        public static bool Deposit(long AccountID, decimal Amount)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {
                string Query = @"BEGIN TRANSACTION;

                                    UPDATE Accounts
                                    SET Balance = (Balance + @Amount)
                                    WHERE ID = @AccountID AND AccountStatusID = 1;

                                    INSERT INTO Transactions (Amount, AccountID, TransactionTypeID, TransactionDate)
                                    VALUES (@Amount, @AccountID, @TransactionType, @TransactionDate);

                                    COMMIT;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@AccountID", AccountID);
                    cmd.Parameters.AddWithValue("@Amount", Amount);
                    cmd.Parameters.AddWithValue("@TransactionType", 1);
                    cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        public static bool Overdraft(long AccountID, decimal Amount)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {
                string Query = @"BEGIN TRANSACTION;

                                    UPDATE Accounts
                                    SET Balance = (Balance - @Amount)
                                    WHERE ID = @AccountID AND AccountStatusID = 1;

                                    INSERT INTO Transactions (Amount, AccountID, TransactionTypeID, TransactionDate)
                                    VALUES (@Amount, @AccountID, @TransactionType, @TransactionDate);

                                    COMMIT;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@AccountID", AccountID);
                    cmd.Parameters.AddWithValue("@Amount", Amount);
                    cmd.Parameters.AddWithValue("@TransactionType", 3);
                    cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        public static List<TransactionDTO>? AccountTransactionsHistory(long AccountID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {
                string Query = @" SELECT Amount, TransactionTypeID AS TransactionType, TransactionDate
		                                    From Transactions
			                                    Where AccountID = @AccountID;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@AccountID", AccountID);

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        List<TransactionDTO>? TransactionsList = new List<TransactionDTO>();

                        while (reader.Read())
                        {

                            TransactionsList.Add(
                                new TransactionDTO(
                                    AccountID,
                                    (long)reader["TransactionType"],
                                     Convert.ToDecimal(reader["Amount"]),
                                     Convert.ToDateTime(reader["TransactionDate"])
                                )
                            );


                        }

                        return TransactionsList;

                    }

                }

            }
        }



    }
}
