using System.ComponentModel.DataAnnotations;


namespace DTO_Layer
{
    public class CountryDTO
    {

        [Required(ErrorMessage = "ID is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "Person ID must be a non-negative number.")]
        public long ID {  get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Country Name must be between 2 and 50 characters.")]
        public string Name { get; set; }
        
        public CountryDTO(long ID, string Name) { 
        
            this.ID = ID;
            this.Name = Name;

        }

        public CountryDTO() { }

    }

    public struct CountryDetails
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public long NumberOfPeople { get; set; }

    }
}
