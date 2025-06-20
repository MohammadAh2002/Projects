using DTO_Layer;
using Helper_Layer;
using System.Data.SQLite;
using System.Data;

namespace Data_Access_Layer
{
    public static class TransferDAL
    {
        public static bool Transfer(TransferDTO TransferDTO)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"BEGIN TRANSACTION;

                                    UPDATE Accounts
                                    SET Balance = Balance - @Amount
                                    WHERE ID = @SourceAccount AND AccountStatusID = 1;

                                    UPDATE Accounts
                                    SET Balance = Balance + @Amount
                                    WHERE ID = @DestinationAccount AND AccountStatusID = 1;

                                    INSERT INTO Transfers (SourceAccountID, DestinationAccountID, Amount, TransferReasonID, TransferDate)
                                    VALUES (@SourceAccount, @DestinationAccount, @Amount, @TransferReason, @TransferDate);

                                    COMMIT;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@SourceAccount", TransferDTO.SourceAccountID);
                    cmd.Parameters.AddWithValue("@DestinationAccount", TransferDTO.DestinationAccountID);
                    cmd.Parameters.AddWithValue("@Amount", TransferDTO.Amount);
                    cmd.Parameters.AddWithValue("@TransferReason", TransferDTO.TransferReasonID);
                    cmd.Parameters.AddWithValue("@TransferDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        public static List<TransferShowDTO>? AccountTransfersHistory(long AccountID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"SELECT SourceAccountID, DestinationAccountID, Amount, TransferReasonID, TransferDate
		                                From Transfers
			                                Where SourceAccountID = @AccountID;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@AccountID", AccountID);

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        List<TransferShowDTO>? TransactionsList = new List<TransferShowDTO>();

                        while (reader.Read())
                        {

                            TransactionsList.Add(
                                new TransferShowDTO(
                                    AccountID,
                                    (long)reader["DestinationAccountID"],
                                     Convert.ToDecimal(reader["Amount"]),
                                    (long)reader["TransferReasonID"],
                                    Convert.ToDateTime(reader["TransferDate"])
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
