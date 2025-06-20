using DTO_Layer;
using Helper_Layer;
using System.Data;
using System.Data.SQLite;

namespace Data_Access_Layer
{
    public static class EmployeeDAL
    {
        public static EmployeeDTO? Find(long ID)
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"Select Salary, HireDate, PersonID, DepartmentID 
		                            From Employees
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
                            return new EmployeeDTO(
                                ID,
                                (decimal)reader["Salary"],
                                true,
                                Convert.ToDateTime(reader["HireDate"]),
                                null,
                                (long)reader["PersonID"],
                                (long)reader["DepartmentID"]
                                );

                        }

                    }

                }

                return null;

            }
        }

        public static EmployeeDTO? FindByPersonID(long PersonID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {
                string Query = @"Select ID, Salary, HireDate, DepartmentID 
		                            From Employees
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

                            return new EmployeeDTO(
                                 (long)reader["ID"],
                                (decimal)reader["Salary"],
                                true,
                               Convert.ToDateTime(reader["HireDate"]),
                                null,
                                PersonID,
                                (long)reader["DepartmentID"]
                                );

                        }

                    }

                }

                return null;


            }
        }

        public static long Add(EmployeeAddDTO EmployeeDTO)
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"Insert into Employees(Salary, IsActive, HireDate, LeaveDate, PersonID, DepartmentID)
	                                values (@Salary, @IsActive, @HireDate, @LeaveDate, @PersonID, @DepartmentID);

                                SELECT last_insert_rowid();";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Salary", EmployeeDTO.Salary);
                    cmd.Parameters.AddWithValue("@IsActive", true);
                    cmd.Parameters.AddWithValue("@HireDate", EmployeeDTO.HireDate.ToString("yyyy-MM-dd"));

                    cmd.Parameters.AddWithValue("@LeaveDate", DBNull.Value);

                    cmd.Parameters.AddWithValue("@PersonID", EmployeeDTO.PersonID);
                    cmd.Parameters.AddWithValue("@DepartmentID", EmployeeDTO.DepartmentID);

                    SQLiteConnection.Open();

                    object Result = cmd.ExecuteScalar();

                    return Convert.ToInt32(Result);
                }
            }

        }

        public static long Update(EmployeeDTO EmployeeDTO)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"Update Employees
                                Set Salary = @Salary, 
                                    DepartmentID = @DepartmentID
                                Where ID = @ID and IsActive = 1; ";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", EmployeeDTO.ID);
                    cmd.Parameters.AddWithValue("@Salary", EmployeeDTO.Salary);
                    cmd.Parameters.AddWithValue("@DepartmentID", EmployeeDTO.DepartmentID);

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery();

                }
            }
        }

        public static bool Delete(long ID)
        {

            bool DeletedUser = false;

            if (UserDAL.IsExistByEmployeeID(ID))
            {
                DeletedUser = UserDAL.DeleteByEmployeeID(ID);
            }
            else        
                DeletedUser = true;

            if (DeletedUser)
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
                {

                    string Query = @"UPDATE Employees SET IsActive = 0 WHERE ID = @ID;";

                    using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                    {

                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@ID", ID);

                        SQLiteConnection.Open();

                        return cmd.ExecuteNonQuery() > 0;

                    }
                }
            }

            return false;
        }

        public static bool DeleteByPersonID(long PersonID)
        {

            bool DeletedUser = false;

            long EmployeeID = FindByPersonID(PersonID).ID;

            if (UserDAL.IsExistByEmployeeID(EmployeeID))
            {
                DeletedUser = UserDAL.DeleteByEmployeeID(EmployeeID);
            }
            else
                DeletedUser = true;

            if (DeletedUser)
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
                {

                    string Query = @"UPDATE Employees SET IsActive = 0 WHERE PersonID = @PersonID;";

                    using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                    {

                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@PersonID", PersonID);

                        SQLiteConnection.Open();

                        return cmd.ExecuteNonQuery() > 0;

                    }
                }
            }

            return false;

        }

        public static bool IsExist(long ID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"SELECT 1
		                        FROM Employees
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
		                        FROM Employees
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
        public static List<EmployeeShowDTO>? GetAll()
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"Select * From VIEW_AllEmployees";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        List<EmployeeShowDTO>? Employees = new List<EmployeeShowDTO>();
                        DateTime? LeaveDate;

                        while (reader.Read())
                        {
                            if (reader["LeaveDate"] == DBNull.Value)
                                LeaveDate = null;
                            else
                                LeaveDate =Convert.ToDateTime(reader["LeaveDate"]);

                            Employees.Add(

                                new EmployeeShowDTO(
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
                                    (string)reader["Country"]
                                    )

                                );

                        }

                        return Employees;

                    }

                }

            }

        }

        public static bool DeActivate(long ID)
        {
            bool DeActivatedUser = false;

            if (UserDAL.DeActivateByEmployeeID(ID))
            {
                DeActivatedUser = UserDAL.DeActivateByEmployeeID(ID);
            }
            else
                DeActivatedUser = true;

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"UPDATE Employees
		                            SET IsActive = 0
			                            Where ID = @ID and IsActive = 1";

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
                string Query = @"UPDATE Employees
		                            SET IsActive = 1
			                            Where ID = @ID and IsActive = 0";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", ID);

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        public static decimal TotalSalaries()
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"Select Sum(Salary)
		                                From Employees";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    SQLiteConnection.Open();

                    object Result = cmd.ExecuteScalar();

                    if (Result == null || Result == DBNull.Value)
                    {
                        return -1;
                    }

                    return Convert.ToDecimal(Result);
                }
            }
        }

    }
}
