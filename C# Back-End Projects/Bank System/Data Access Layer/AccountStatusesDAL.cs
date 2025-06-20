using DTO_Layer;
using Helper_Layer;
using System.Data.SQLite;
using System.Data;

namespace Data_Access_Layer
{
    public static class AccountStatusesDAL
    {
        public static AccountStatusesDTO? Find(long ID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"Select Name, Description From AccountStatuses
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
                            return new AccountStatusesDTO(
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

        public static AccountStatusesDTO? Find(string Name)
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"Select ID, Description From AccountStatuses
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

                            return new AccountStatusesDTO(
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

        public static long Add(AccountStatusesAddDTO AccountStatusDTO)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {
                string Query = @"
                                Insert into AccountStatuses(Name, Description)
		                                values (@Name, @Description);

	                                 SELECT last_insert_rowid();";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Name", AccountStatusDTO.Name);
                    cmd.Parameters.AddWithValue("@Description", AccountStatusDTO.Description);

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

                string Query = @"
                                UPDATE AccountStatuses SET
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

                string Query = @"DELETE FROM AccountStatuses 
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
		                            FROM AccountStatuses
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

        public static List<AccountStatusesDTO>? GetAll()
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"
    	                        SELECT ID, Name, Description
		                                 FROM AccountStatuses;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    List<AccountStatusesDTO> AccountStatusesList = new List<AccountStatusesDTO>();

                    cmd.CommandType = CommandType.Text;

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AccountStatusesList.Add(
                                new AccountStatusesDTO(
                                  (long)reader["ID"],
                                  (string)reader["Name"],
                                  (string)reader["Description"]
                                )
                            );
                        }

                        return AccountStatusesList;
                    }
                }
            }

        }

    }
}
