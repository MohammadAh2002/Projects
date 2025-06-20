using DTO_Layer;
using System.Data.SQLite;
using System.Data;
using Helper_Layer;

namespace Data_Access_Layer
{
    public class DepartmentDAL
    {
        public static DepartmentDTO? Find(long ID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"Select Name, Description From Departments
		                                Where ID = @ID;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", ID);

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DepartmentDTO(
                                  ID,
                                  (string)reader["Name"],
                                  (string)reader["Description"]
                            );
                        }
                    }
                }
            }
            return null;
        }

        public static DepartmentDTO? Find(string Name)
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {
                string Query = @"Select ID, Description From Departments
		                                Where Name = @Name;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Name", Name);

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            return new DepartmentDTO(
                                  (long)reader["ID"],
                                  Name,
                                  (string)reader["Description"]
                            );

                        }
                    }
                }
            }

            return null;

        }

        public static long Add(DepartmentAddDTO DepartmentDTO)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"Insert into Departments (Name, Description)
		                            values (@Name, @Description);

                                SELECT last_insert_rowid();";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Name", DepartmentDTO.Name);
                    cmd.Parameters.AddWithValue("@Description", DepartmentDTO.Description);

                    SQLiteConnection.Open();

                    object Result = cmd.ExecuteScalar();

                    return Convert.ToByte(Result);

                }
            }

        }

        public static bool UpdateDescription(long ID, string Description)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"UPDATE Departments SET
				                        Description = @Description
					                        Where ID = @ID;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Description", Description);

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        public static bool Delete(long ID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"DELETE FROM Departments
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

                string Query = @"SELECT 1
		                            FROM Departments
			                            WHERE ID = @ID;";

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

        public static List<DepartmentDTO> GetAll()
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"SELECT ID, Name, Description FROM Departments; ";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    List<DepartmentDTO> DepartmentsList = new List<DepartmentDTO>();

                    cmd.CommandType = CommandType.Text;

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DepartmentsList.Add(
                                new DepartmentDTO (
                                  (long)reader["ID"],
                                  (string)reader["Name"],
                                  (string)reader["Description"]
                                )
                            );
                        }

                        return DepartmentsList;
                    }
                }
            }

        }

        public static stDepartmentDetails? DepartmentDetails(long ID)
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"SELECT * FROM VIEW_DepartmentDetails WHERE ID = @ID;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", ID);

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            stDepartmentDetails? DepartmentDetails =  new stDepartmentDetails
                            
                            {
                                ID = reader.GetByte(reader.GetOrdinal("ID")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                NumberOfEmployees = reader.GetInt64(reader.GetOrdinal("NumberOfEmployees")),
                                TotalSalaries = reader.GetDecimal(reader.GetOrdinal("TotalSalaries"))
                            };

                            return DepartmentDetails;
                        }

                    }
                }
            }

            return null;
        }



    }
}
