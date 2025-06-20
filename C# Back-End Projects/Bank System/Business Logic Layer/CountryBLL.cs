using Data_Access_Layer;
using DTO_Layer;

namespace Business_Logic_Layer
{
    public class CountryBLL
    {

        public long ID { get; set; }
        public string Name { get; set; }

        public CountryBLL(CountryDTO CDTO)
        {

            ID = CDTO.ID;
            Name = CDTO.Name;

        }

        public CountryBLL(string Name)
        {
            ID = -1;
            this.Name = Name;

        }

        public CountryDTO CDTO
        {
            get
            {
                return new CountryDTO(ID, Name);
            }
        }

        static public List<CountryDTO>? GetAllCountries()
        {

            return CountryDAL.GetAllCountries();

        }

        public static CountryBLL? Find(long ID)
        {
            CountryDTO? Country = CountryDAL.Find(ID);

            if (Country == null)
                return null;

            return new CountryBLL(Country);
        }

        public static CountryBLL? Find(string Name)
        {
            CountryDTO? Country = CountryDAL.Find(Name);

            if (Country == null)
                return null;

            return new CountryBLL(Country);
        }

        public bool Add()
        {
            ID = CountryDAL.Add(Name);

            return ID != -1;
        }

        public bool Update()
        {
            return CountryDAL.Update(CDTO);
        }

        public static bool Delete(long ID)
        {
            return CountryDAL.Delete(ID);
        }
        public static bool Delete(string Name)
        {
            return CountryDAL.Delete(Name);
        }

        public static bool IsExist(long ID)
        {
            return CountryDAL.IsExist(ID);
        }
        public static bool IsExist(string Name)
        {
            return CountryDAL.IsExist(Name);
        }

        public static List<CountryDetails>? CountriesDetails()
        {

            return CountryDAL.CountriesDetails();

        }

        public CountryDetails? CountryDetails()
        {

            return CountryDAL.CountryDetails(ID);

        }
        public static CountryDetails? CountryDetails(long ID)
        {

            return CountryDAL.CountryDetails(ID);

        }

    }
}
