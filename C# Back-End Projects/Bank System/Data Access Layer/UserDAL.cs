using DTO_Layer;
using System.Data.SQLite;
using System.Data;
using Helper_Layer;

namespace Data_Access_Layer
{
    public static class UserDAL
    {
        public static UserDTO? Find(long ID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"Select Username, Password, EmployeeID
		                                From Users
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

                            return new UserDTO(
                                            ID,
                                            (string)reader["Username"],
                                            (string)reader["Password"],
                                            true,
                                            (long)reader["EmployeeID"]
                                        );


                        }
                    }

                }
            }

            return null;

        }

        public static UserDTO? Find(string Username, string Password)
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"Select ID, EmployeeID
		                            From Users
			                            Where Username = @Username and Password = @Password and IsActive = 1";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Username", Username);
                    cmd.Parameters.AddWithValue("@Password", Password);

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {

                            return new UserDTO(
                                            (long)reader["ID"],
                                            Username,
                                            Password,
                                            true,
                                            (long)reader["EmployeeID"]
                                            );
                        }

                    }

                }
            }

            return null;
        }

        public static long Add(UserDTO User)
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"INSERT INTO Users (Username, Password, IsActive, EmployeeID)
                                            VALUES (@Username, @Password, @IsActive, @EmployeeID);
                                 SELECT last_insert_rowid();";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Username", User.Username);
                    cmd.Parameters.AddWithValue("@Password", User.Password);
                    cmd.Parameters.AddWithValue("@IsActive", User.IsActive);
                    cmd.Parameters.AddWithValue("@EmployeeID", User.EmployeeID);


                    SQLiteConnection.Open();

                    object Result = cmd.ExecuteScalar();

                    return Convert.ToInt32(Result);
                }
            }

        }
        public static bool Update(UserDTO User)
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"UPDATE Users
		                            SET Username = @Username,
			                            Password = @Password
				                            Where ID = @ID";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", User.ID);
                    cmd.Parameters.AddWithValue("@Username", User.Username);
                    cmd.Parameters.AddWithValue("@Password", User.Password);

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }

        }

        public static bool Delete(long ID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"UPDATE Users SET IsActive = 0 WHERE ID = @ID;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", ID);

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        public static bool DeleteByEmployeeID(long EmployeeID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"UPDATE Users SET IsActive = 0 WHERE EmployeeID = @EmployeeID;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);

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
		                            FROM Users
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

        public static bool IsExistByEmployeeID(long EmployeeID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"SELECT 1
		                            FROM Users
			                            WHERE EmployeeID = @EmployeeID and IsActive = 1;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                    SQLiteConnection.Open();

                    object Result = cmd.ExecuteScalar();

                    return Result != null;

                }
            }
        }

        public static bool IsExist(string Username)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"SELECT 1
		                            FROM Users
			                            WHERE Username Like @Username and IsActive = 1;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Username", Username);

                    SQLiteConnection.Open();

                    object Result = cmd.ExecuteScalar();

                    return Result != null;

                }
            }

        }

        public static List<UserShowDTO>? GetAll()
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"Select * From VIEW_AllUsers";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        List<UserShowDTO>? Users = new List<UserShowDTO>();
                        DateTime? LeaveDate;

                        while (reader.Read())
                        {
                            if (reader["LeaveDate"] == DBNull.Value)
                                LeaveDate = null;
                            else
                                LeaveDate =Convert.ToDateTime(reader["LeaveDate"]);

                            Users.Add(

                                new UserShowDTO(
                                    (long)reader["ID"],
                                    (string)reader["FullName"],
                                    (decimal)reader["Salary"],
                                   Convert.ToDateTime(reader["HireDate"]),
                                    LeaveDate,
                                    (string)reader["Department"],
                                    (string)reader["Gender"],
                                    (string)reader["Email"],
                                    (string)reader["PhoneNumber"],
                                    (string)reader["Address"],
                                    Convert.ToDateTime(reader["DateOfBirth"]),
                                    (string)reader["Country"],
                                    (string)reader["Username"],
                                   true
                                    )

                                );

                        }

                        return Users;

                    }

                }

            }

        }

        public static bool DeActivate(long ID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"UPDATE Users
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

        public static bool DeActivateByEmployeeID(long EmployeeID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"UPDATE Users
		                            SET IsActive = 0
			                            Where EmployeeID = @EmployeeID";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        public static bool Activate(long ID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"UPDATE Users
		                            SET IsActive = 1
			                            Where ID = @ID;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", ID);

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        public static bool ActivateByEmployeeID(long EmployeeID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"UPDATE Users
		                            SET IsActive = 1
			                            Where EmployeeID = @EmployeeID;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }

    }
}
