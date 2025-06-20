using Data_Access_Layer;
using DTO_Layer;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace Business_Logic_Layer
{
    public class PersonBLL
    {

        public long ID { get; set; }
        public string NationalNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string? ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + SecondName + " " + LastName;
            }
        }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsDeleted { get; set; }
        public CountryBLL? Country { get; set; }

        public PersonBLL(PersonDTO? PDTO)
        {

            ID = PDTO.ID;
            NationalNumber = PDTO.NationalNumber;
            FirstName = PDTO.FirstName;
            SecondName = PDTO.SecondName;
            ThirdName = PDTO.ThirdName;
            LastName = PDTO.LastName;
            Gender = PDTO.Gender;
            Email = PDTO.Email;
            PhoneNumber = PDTO.PhoneNumber;
            Address = PDTO.Address;
            DateOfBirth = PDTO.DateOfBirth;
            IsDeleted = PDTO.IsDeleted;
            Country = CountryBLL.Find(PDTO.CountryID);

        }
        public PersonBLL(PersonAddDTO? PADTO)
        {

            ID = -1;
            NationalNumber = PADTO.NationalNumber;
            FirstName = PADTO.FirstName;
            SecondName = PADTO.SecondName;
            ThirdName = PADTO.ThirdName;
            LastName = PADTO.LastName;

            if (PADTO.Gender == 'M')
                Gender = "Male";
            else
                Gender = "Female";

            Email = PADTO.Email;
            PhoneNumber = PADTO.PhoneNumber;
            Address = PADTO.Address;
            DateOfBirth = PADTO.DateOfBirth;

            IsDeleted = false;
            Country = CountryBLL.Find(PADTO.CountryID);

        }
        public PersonBLL(PersonUpdateDTO PUDTO)
        {

            PersonBLL? Person = Find(PUDTO.ID);

            ID = PUDTO.ID;
            NationalNumber = Person.NationalNumber;

            FirstName = PUDTO.FirstName;
            SecondName = PUDTO.SecondName;
            ThirdName = PUDTO.ThirdName;
            LastName = PUDTO.LastName;

            Gender = Person.Gender;
            Email = PUDTO.Email;
            PhoneNumber = PUDTO.PhoneNumber;
            Address = PUDTO.Address;
            DateOfBirth = Person.DateOfBirth;

            IsDeleted = Person.IsDeleted;

            Country = CountryBLL.Find(PUDTO.CountryID);

        }

        public PersonShowDTO PSDTO
        {

            get
            {

                return new PersonShowDTO(ID, NationalNumber, FullName,
                    Gender, Email, PhoneNumber, Address, DateOfBirth, Country.Name);

            }

        }
        public PersonDTO PDTO
        {

            get
            {

                return new PersonDTO(ID, NationalNumber, FirstName, SecondName, ThirdName, LastName,
                    Gender, Email, PhoneNumber, Address, DateOfBirth, IsDeleted, Country.ID);

            }

        }

        static public PersonBLL? Find(long ID)
        {

            PersonDTO? PDTO = PersonDAL.FindPerson(ID);

            if (PDTO == null || PDTO.IsDeleted)
            {
                return null;
            }

            PersonBLL? Person = new PersonBLL(PDTO);

            return Person;

        }

        public bool Add()
        {

            ID = PersonDAL.AddPerson(PDTO);

            return ID != -1;

        }

        public bool Update()
        {

            return PersonDAL.UpdatePerson(PDTO) > 0;

        }

        public static bool DeletePerson(long ID)
        {

            return PersonDAL.DeletePerson(ID);

        }

        public static bool IsExist(long ID)
        {

            return PersonDAL.IsExist(ID);

        }

        public static List<PersonShowDTO> GetAll()
        {

            List<PersonDTO> People = PersonDAL.GetAll();

            List<PersonShowDTO> PeopleList = new List<PersonShowDTO>();

            foreach (PersonDTO Person in People)
            {

                StringBuilder FullName = new StringBuilder();
                FullName.Append(Person.FirstName)
                  .Append(" ")
                  .Append(Person.SecondName)
                  .Append(" ")
                  .Append(Person.LastName);

                string Country = CountryBLL.Find(Person.CountryID).Name;

                PeopleList.Add(

                    new PersonShowDTO(
                        Person.ID,
                        Person.NationalNumber,
                        FullName.ToString(),
                        Person.Gender,
                        Person.Email,
                        Person.PhoneNumber,
                        Person.Address,
                        Person.DateOfBirth,
                        Country
                        )
                    );
            }

            return PeopleList;

        }
        public static List<PersonShowDTO> GetAllDeleted()
        {

            return PersonDAL.GetAllDeleted();

        }

    }
}
