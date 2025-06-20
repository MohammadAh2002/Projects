using DTO_Layer;
using Helper_Layer;
using System.Data;
using System.Data.SQLite;

namespace Data_Access_Layer
{
    public static class CountryDAL
    {

        public static List<CountryDTO>? GetAllCountries()
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {
                string Query = "SELECT * FROM Countries";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    List<CountryDTO> Countries = new List<CountryDTO>();

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Countries.Add(new CountryDTO(

                                reader.GetInt64(reader.GetOrdinal("ID")),
                                reader.GetString(reader.GetOrdinal("Name"))

                            ));

                        }
                    }

                    return Countries;
                }

            }
        }

        public static CountryDTO? Find(long ID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {
                string Query = "SELECT Name FROM Countries WHERE ID = @ID";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", ID);

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {

                            return new CountryDTO(

                                 ID,
                                 reader.GetString(reader.GetOrdinal("Name"))

                            );

                        }
                    }

                }
            }

            return null;

        }

        public static CountryDTO? Find(string Name)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {
                string Query = "SELECT ID FROM Countries WHERE Name = @Name";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Name", Name);

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {

                            return new CountryDTO(

                                reader.GetInt64(reader.GetOrdinal("ID")),
                                Name

                            );

                        }
                    }

                }
            }

            return null;

        }

        public static long Add(string Name)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"
                                INSERT INTO Countries (Name) VALUES (@Name);
                                    SELECT last_insert_rowid();";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name", Name);

                    SQLiteConnection.Open();

                    object? Result = cmd.ExecuteScalar();

                    if (Result == null || Result == DBNull.Value)
                    {

                        return -1; 

                    }

                    return Convert.ToInt64(Result);

                }
            }
        }

        public static bool Update(CountryDTO CDTO)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {
                string Query = @"UPDATE Countries SET 
                                            Name = @Name
                                                WHERE ID = @ID";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", CDTO.ID);
                    cmd.Parameters.AddWithValue("@Name", CDTO.Name);

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        public static bool Delete(long ID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {
                string Query = @"DELETE FROM Countries 
                                                WHERE ID = @ID";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", ID);

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }
        public static bool Delete(string Name)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {
                string Query = @"DELETE FROM Countries 
                                                WHERE Name = @Name";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Name", Name);

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        public static bool IsExist(long ID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {
                string Query = @"SELECT 1 FROM Countries 
                                            WHERE ID = @ID LIMIT 1";

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
        public static bool IsExist(string Name)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {
                string Query = @"SELECT 1 FROM Countries 
                                            WHERE Name = @Name LIMIT 1";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Name", Name);

                    SQLiteConnection.Open();

                    object Result = cmd.ExecuteScalar();

                    return Result != null;

                }
            }
        }

        public static List<CountryDetails>? CountriesDetails()
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"SELECT * From VIEW_CountriesDetails";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        List<CountryDetails> CountriesDetailsList = new List<CountryDetails>();

                        while (reader.Read())
                        {

                            CountriesDetailsList.Add(

                                new CountryDetails
                                {
                                    ID = reader.GetInt64(reader.GetOrdinal("ID")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    NumberOfPeople = reader.GetInt64(reader.GetOrdinal("NumberOfPeople"))

                                }

                            );

                        }

                        return CountriesDetailsList;

                    }

                }



            }

        }

        public static CountryDetails? CountryDetails(long ID)
        {
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {

                string Query = @"SELECT * From VIEW_CountryDetails
                                            Where ID = @ID;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("ID", ID);

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            return new CountryDetails
                            {
                                ID = reader.GetInt64(reader.GetOrdinal("ID")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                NumberOfPeople = reader.GetInt64(reader.GetOrdinal("NumberOfPeople"))

                            };

                        }

                    }

                }

                return null;

            }

        }
    }
}
