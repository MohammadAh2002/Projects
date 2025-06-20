using DTO_Layer;
using System.Data.SQLite;
using System.Data;
using Helper_Layer;

namespace Data_Access_Layer
{
    public static class UserLogsDAL
    {
        public static bool Logout(long UserID, DateTime? LoginTime)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"INSERT INTO LogIns(UserID, LogInTime, logOutTime)
                                    VALUES (@UserID, @LogInTime, @logOutTime);";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@LogInTime", LoginTime?.ToString("yyyy-MM-dd HH:mm"));
                    cmd.Parameters.AddWithValue("@logOutTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        public static List<stUserLogsHistory>? UserLogsHistory(long ID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"Select LogInTime, logOutTime
		                            From LogIns
			                            Where UserID = @ID;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    List<stUserLogsHistory>? Logs = new List<stUserLogsHistory>();

                    cmd.Parameters.AddWithValue("@ID", ID);

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Logs.Add(new stUserLogsHistory
                            {

                                LoginTime = Convert.ToDateTime(reader["LogInTime"]),
                                LogoutTime = Convert.ToDateTime(reader["LogOutTime"])

                            }
                            );

                        }
                    }
                    return Logs;
                }

            }
        }

    }
}
