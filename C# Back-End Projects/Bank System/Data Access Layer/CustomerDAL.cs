using DTO_Layer;
using Helper_Layer;
using System.Data.SQLite;
using System.Data;

namespace Data_Access_Layer
{
    public static class CustomerDAL
    {
        public static CustomerDTO? Find(long ID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"Select PinCode, CreationDate, PersonID
		                            From Customers
			                            Where ID = @ID and IsActive = 1;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", ID);

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {

                            return new CustomerDTO(
                                            ID,
                                            (string)reader["PinCode"],
                                            true,
                                           Convert.ToDateTime(reader["CreationDate"]),
                                            (long)reader["PersonID"]
                                        );


                        }
                    }

                }
            }

            return null;
        }
        public static CustomerDTO? FindByPersonID(long PersonID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {
                string Query = @"Select ID, PinCode, CreationDate
		                                From Customers
			                                Where PersonID = @PersonID and IsActive = 1;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@PersonID", PersonID);

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {

                            return new CustomerDTO(
                                            (long)reader["ID"],
                                            (string)reader["PinCode"],
                                            true,
                                           Convert.ToDateTime(reader["CreationDate"]),
                                            PersonID
                                        );


                        }
                    }

                }
            }

            return null;
        }

        public static bool Delete(long ID)
        {

            if (HasAccount(ID))
            {

                if (!AccountDAL.DeleteCustomerAllAccounts(ID))
                    return false;

            }

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"UPDATE Customers
		                                SET IsActive = 0 
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
        public static bool DeleteByPersonID(long PersonID)
        {

            long CustomerID = FindByPersonID(PersonID).ID;

            if (HasAccount(CustomerID))
            {

                if (!AccountDAL.DeleteCustomerAllAccounts(CustomerID))
                    return false;

            }

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"UPDATE Customers
		                                SET IsActive = 0 
		                                WHERE PersonID = @PersonID;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@PersonID", PersonID);

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }

        }

        public static bool IsExist(long ID)
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"SELECT 1
		                            FROM Customers
			                            WHERE ID = @ID and IsActive = 1;";

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

        public static bool IsExistByPersonID(long PersonID)
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"SELECT 1
		                            FROM Customers
			                            WHERE PersonID = @PersonID and IsActive = 1;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@PersonID", PersonID);

                    SQLiteConnection.Open();

                    object Result = cmd.ExecuteScalar();

                    return Result != null;

                }
            }

        }
        public static long Add(CustomerAddDTO CustomerDTO)
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @" INSERT INTO Customers(PinCode, PersonID, IsActive, CreationDate)
                                        VALUES (@PinCode, @PersonID, @IsActive, @CreationDate);
                                  SELECT last_insert_rowid();";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@PinCode", CustomerDTO.PinCode);
                    cmd.Parameters.AddWithValue("@PersonID", CustomerDTO.PersonID);
                    cmd.Parameters.AddWithValue("@IsActive", true);
                    cmd.Parameters.AddWithValue("@CreationDate", DateTime.Now.ToString("yyyy-MM-dd"));


                    SQLiteConnection.Open();

                    object Result = cmd.ExecuteScalar();

                    return Convert.ToInt32(Result);
                }
            }

        }

        public static bool Update(long ID, string PinCode)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"UPDATE Customers
		                            SET PinCode = @PinCode
				                            Where ID = @ID and IsActive = 1";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@PinCode", PinCode);

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }


        }

        public static List<CustomerShowDTO>? GetAll()
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"Select * From VIEW_AllCustomers";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        List<CustomerShowDTO>? CustomersList = new List<CustomerShowDTO>();

                        while (reader.Read())
                        {

                            CustomersList.Add(

                                new CustomerShowDTO(
                                    (long)reader["ID"],
                                    (long)reader["PersonID"],
                                    (string)reader["NationalNumber"],
                                    (string)reader["FullName"],
                                    (string)reader["Gender"],
                                    (string)reader["Email"],
                                    (string)reader["PhoneNumber"],
                                    (string)reader["Address"],
                                    Convert.ToDateTime(reader["DateOfBirth"]),
                                    (string)reader["Country"],
                                    true,
                                   Convert.ToDateTime(reader["CreationDate"])
                                    )
                                );

                        }

                        return CustomersList;

                    }

                }

            }

        }

        public static bool DeActivate(long ID)
        {

            if (HasAccount(ID))
            {

                if (!AccountDAL.DeleteCustomerAllAccounts(ID))
                    return false;

            }

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"UPDATE Customers
		                                SET IsActive = 0
			                                Where ID = @ID";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", ID);

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        public static bool Activate(long ID)
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"UPDATE Customers
		                            SET IsActive = 1
			                            Where ID = @ID";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", ID);

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        public static bool HasAccount(long CustomerID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {
                string Query = @"SELECT 1
                                    FROM Accounts
                                    WHERE CustomerID = @CustomerID
                                    LIMIT 1;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                    SQLiteConnection.Open();

                    object Result = cmd.ExecuteScalar();

                    return Result != null;

                }
            }

        }
    }
}
