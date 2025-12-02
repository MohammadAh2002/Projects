using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.EntitiesConfiguration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {

            builder.HasIndex(Country => Country.Name)
                          .IsUnique();

            builder.HasIndex(Country => Country.Nationality)
                         .IsUnique();

            builder.HasData(
                new Country { ID = 1, Name = "Germany", Nationality = "German" },
                new Country { ID = 2, Name = "Spain", Nationality = "Spanish" },
                new Country { ID = 3, Name = "France", Nationality = "French" },
                new Country { ID = 4, Name = "England", Nationality = "English" },
                new Country { ID = 5, Name = "Italy", Nationality = "Italian" },
                new Country { ID = 6, Name = "Portugal", Nationality = "Portuguese" },
                new Country { ID = 7, Name = "Netherlands", Nationality = "Dutch" },
                new Country { ID = 8, Name = "Belgium", Nationality = "Belgian" },
                new Country { ID = 9, Name = "Russia", Nationality = "Russian" },
                new Country { ID = 10, Name = "Turkey", Nationality = "Turkish" },
                new Country { ID = 11, Name = "Argentina", Nationality = "Argentine" },
                new Country { ID = 12, Name = "Brazil", Nationality = "Brazilian" },
                new Country { ID = 13, Name = "Mexico", Nationality = "Mexican" },
                new Country { ID = 14, Name = "USA", Nationality = "American" },
                new Country { ID = 15, Name = "Scotland", Nationality = "Scottish" },
                new Country { ID = 16, Name = "Greece", Nationality = "Greek" },
                new Country { ID = 17, Name = "Switzerland", Nationality = "Swiss" },
                new Country { ID = 18, Name = "Austria", Nationality = "Austrian" },
                new Country { ID = 19, Name = "Denmark", Nationality = "Danish" },
                new Country { ID = 20, Name = "Norway", Nationality = "Norwegian" },
                new Country { ID = 21, Name = "Sweden", Nationality = "Swedish" },
                new Country { ID = 22, Name = "Poland", Nationality = "Polish" },
                new Country { ID = 23, Name = "Ukraine", Nationality = "Ukrainian" },
                new Country { ID = 24, Name = "Serbia", Nationality = "Serbian" },
                new Country { ID = 25, Name = "Croatia", Nationality = "Croatian" },
                new Country { ID = 26, Name = "Czech Republic", Nationality = "Czech" },
                new Country { ID = 27, Name = "Japan", Nationality = "Japanese" },
                new Country { ID = 28, Name = "South Korea", Nationality = "Korean" },
                new Country { ID = 29, Name = "China", Nationality = "Chinese" },
                new Country { ID = 30, Name = "Australia", Nationality = "Australian" },
                new Country { ID = 31, Name = "Saudi Arabia", Nationality = "Saudi" },
                new Country { ID = 32, Name = "Egypt", Nationality = "Egyptian" }
            );

        }
    }
}
