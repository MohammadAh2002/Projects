using DTO_Layer;
using Helper_Layer;
using System.Data.SQLite;
using System.Data;
using static DTO_Layer.TransactionTypeDTO;

namespace Data_Access_Layer
{
    public static class TransactionTypesDAL
    {
        public static TransactionTypeDTO? Find(long ID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"Select Name, Description From TransactionTypes
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
                            return new TransactionTypeDTO(
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

        public static TransactionTypeDTO? Find(string Name)
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"Select ID, Description From TransactionTypes
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

                            return new TransactionTypeDTO(
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

        public static long Add(TransactionTypeAddDTO TransactionTypeDTO)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"Insert into TransactionTypes (Name, Description)
		                            values (@Name, @Description);
                                
                                SELECT last_insert_rowid();";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Name", TransactionTypeDTO.Name);
                    cmd.Parameters.AddWithValue("@Description", TransactionTypeDTO.Description);

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

                string Query = @"UPDATE TransactionTypes SET
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

                string Query = @"DELETE FROM TransactionTypes 
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
		                            FROM TransactionTypes
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

        public static List<TransactionTypeDTO> GetAll()
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"SELECT ID, Name, Description
		                                FROM TransactionTypes;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    List<TransactionTypeDTO> DepartmentsList = new List<TransactionTypeDTO>();

                    cmd.CommandType = CommandType.Text;

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DepartmentsList.Add(
                                new TransactionTypeDTO(
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

    }
}
