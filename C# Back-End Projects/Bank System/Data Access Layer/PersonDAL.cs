using DTO_Layer;
using System.Data.SQLite;
using System.Data;
using Helper_Layer;

namespace Data_Access_Layer
{
    public class PersonDAL
    {

        public static PersonDTO? FindPerson(long ID)
        {

            string? ThirdName;

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection)) {

                string Query = @"Select * From VIEW_FindPerson
                                           WHERE ID = @ID";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", ID);
                    
                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            if (reader["ThirdName"] == DBNull.Value)
                                ThirdName = null;
                            else
                                ThirdName = (string)reader["ThirdName"];

                            return new PersonDTO(
                                            ID,
                                            (string)reader["NationalNumber"],
                                            (string)reader["FirstName"],
                                            (string)reader["SecondName"],
                                            ThirdName,
                                            (string)reader["LastName"],
                                            (string)reader["Gender"],
                                            (string)reader["Email"],
                                            (string)reader["PhoneNumber"],
                                            (string)reader["Address"],
                                            Convert.ToDateTime(reader["DateOfBirth"]),
                                            Convert.ToBoolean(reader["IsDeleted"]),
                                            (long)reader["CountryID"]

                            );

                        }

                    }

                }

                return null;
            
            }
             

        }

        public static long AddPerson(PersonDTO PDTO)
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {
                string Query = @"Insert into People (NationalNumber, FirstName, SecondName, ThirdName, LastName, Gender,
						                             Email, PhoneNumber, Address, DateOfBirth, IsDeleted, CountryID)
	                                    values (@NationalNumber, @FirstName, @SecondName, @ThirdName, @LastName, @Gender,
						                        @Email, @PhoneNumber, @Address, @DateOfBirth, @IsDeleted, @CountryID);

                                SELECT last_insert_rowid();";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection)) {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@NationalNumber", PDTO.NationalNumber);
                    cmd.Parameters.AddWithValue("@FirstName", PDTO.FirstName);
                    cmd.Parameters.AddWithValue("@SecondName", PDTO.SecondName);

                    if(PDTO.ThirdName != null)
                        cmd.Parameters.AddWithValue("@ThirdName", PDTO.ThirdName);
                    else
                        cmd.Parameters.AddWithValue("@ThirdName", DBNull.Value);

                    cmd.Parameters.AddWithValue("@LastName", PDTO.LastName);

                    if(PDTO.Gender == "Male")
                        cmd.Parameters.AddWithValue("@Gender", "M");
                    else
                        cmd.Parameters.AddWithValue("@Gender", "F");

                    cmd.Parameters.AddWithValue("@Email", PDTO.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", PDTO.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", PDTO.Address);
                    cmd.Parameters.AddWithValue("@DateOfBirth", PDTO.DateOfBirth.ToString("yyyy-MM-dd"));

                    cmd.Parameters.AddWithValue("@CountryID", PDTO.CountryID);
                    cmd.Parameters.AddWithValue("@IsDeleted", PDTO.IsDeleted);

                    SQLiteConnection.Open();

                    object Result = cmd.ExecuteScalar();

                    return Convert.ToInt32(Result);
                } 
            }
           
        }

        public static long UpdatePerson(PersonDTO PUDTO)
        {

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {
                string Query = @"UPDATE People
				                        SET
				                        FirstName = @FirstName, 
				                        SecondName = @SecondName,
				                        ThirdName = @ThirdName,
				                        LastName = @LastName,
				                        Email = @Email,
				                        PhoneNumber = @PhoneNumber,
				                        Address = @Address
					                        Where ID = @ID and IsDeleted = 0;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ID", PUDTO.ID);
                    cmd.Parameters.AddWithValue("@FirstName", PUDTO.FirstName);
                    cmd.Parameters.AddWithValue("@SecondName", PUDTO.SecondName);
                    if (PUDTO.ThirdName != null)
                        cmd.Parameters.AddWithValue("@ThirdName", PUDTO.ThirdName);
                    else
                        cmd.Parameters.AddWithValue("@ThirdName", DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", PUDTO.LastName);
                    cmd.Parameters.AddWithValue("@Email", PUDTO.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", PUDTO.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", PUDTO.Address);

                    SQLiteConnection.Open();

                    return cmd.ExecuteNonQuery();

                }
            }
        
        }

        public static bool DeletePerson(long ID)
        {

            bool DeletedEmployee = false, DeletedCustomer = false;

            if (EmployeeDAL.IsExistByPersonID(ID))
            {
                DeletedEmployee = EmployeeDAL.DeleteByPersonID(ID);
            }
            else
                DeletedEmployee = true;

            if (CustomerDAL.IsExistByPersonID(ID))
            {
                DeletedCustomer = CustomerDAL.DeleteByPersonID(ID);
            }
            else
                DeletedCustomer = true;

            if (DeletedCustomer && DeletedEmployee)
            {

                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
                {
                    string Query = @"UPDATE People SET IsDeleted = 1 WHERE ID = @ID;";

                    using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@ID", ID);

                        SQLiteConnection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;


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
		                            FROM People
			                            WHERE ID = @ID and IsDeleted = 0;";
             
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

        public static List<PersonDTO> GetAll()
        {

            string? ThirdName;

            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {
                string Query = @"Select *
		                            From People
			                            Where IsDeleted = 0;";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    List<PersonDTO> People = new List<PersonDTO>();

                    SQLiteConnection.Open();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            if (reader["ThirdName"] == DBNull.Value)
                                ThirdName = null;
                            else
                                ThirdName = (string)reader["ThirdName"];

                            People.Add(

                                new PersonDTO(
                                                (long)reader["ID"],
                                                (string)reader["NationalNumber"],
                                                (string)reader["FirstName"],
                                                (string)reader["SecondName"],
                                                ThirdName,
                                                (string)reader["LastName"],
                                                (string)reader["Gender"],
                                                (string)reader["Email"],
                                                (string)reader["PhoneNumber"],
                                                (string)reader["Address"],
                                                Convert.ToDateTime(reader["DateOfBirth"]),
                                                Convert.ToBoolean(reader["IsDeleted"]),
                                                (long)reader["CountryID"]

                                )

                            );

                        }
                    }

                    return People;
                }

            }
        }
        public static List<PersonShowDTO> GetAllDeleted()
        {
          
            using (SQLiteConnection SQLiteConnection = new SQLiteConnection(clsSettings.DatabaseConnection))
            {
                string Query = @"Select * From VIEW_AllDeletedPeople ";

                using (SQLiteCommand cmd = new SQLiteCommand(Query, SQLiteConnection))
                {

                    cmd.CommandType = CommandType.Text;

                    SQLiteConnection.Open();          

                    List<PersonShowDTO> People = new List<PersonShowDTO>();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            People.Add(

                                new PersonShowDTO(
                                        (long)reader["ID"],
                                        (string)reader["NationalNumber"],
                                        (string)reader["FullName"],
                                        (string)reader["Gender"],
                                        (string)reader["Email"],
                                        (string)reader["PhoneNumber"],
                                        (string)reader["Address"],
                                        Convert.ToDateTime(reader["DateOfBirth"]),
                                        (string)reader["CountryName"]
                                    )
                                );

                        }
                    }

                    return People;
                
                }

            }
        }
    }
}
