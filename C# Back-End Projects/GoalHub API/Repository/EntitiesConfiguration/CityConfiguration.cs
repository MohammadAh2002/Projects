using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntitiesConfiguration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {

        public void Configure(EntityTypeBuilder<City> builder)
        {

            builder.HasIndex(City => City.Name)
                          .IsUnique();
        

            builder.HasData(
                new City { ID = 1, Name = "Berlin", CountryID = 1 },
                new City { ID = 2, Name = "Munich", CountryID = 1 },
                new City { ID = 3, Name = "Hamburg", CountryID = 1 },
                new City { ID = 4, Name = "Cologne", CountryID = 1 },
                new City { ID = 5, Name = "Frankfurt", CountryID = 1 },
                new City { ID = 6, Name = "Madrid", CountryID = 2 },
                new City { ID = 7, Name = "Barcelona", CountryID = 2 },
                new City { ID = 8, Name = "Valencia", CountryID = 2 },
                new City { ID = 9, Name = "Seville", CountryID = 2 },
                new City { ID = 10, Name = "Zaragoza", CountryID = 2 },
                new City { ID = 11, Name = "Paris", CountryID = 3 },
                new City { ID = 12, Name = "Marseille", CountryID = 3 },
                new City { ID = 13, Name = "Lyon", CountryID = 3 },
                new City { ID = 14, Name = "Toulouse", CountryID = 3 },
                new City { ID = 15, Name = "Nice", CountryID = 3 },
                new City { ID = 16, Name = "London", CountryID = 4 },
                new City { ID = 17, Name = "Birmingham", CountryID = 4 },
                new City { ID = 18, Name = "Manchester", CountryID = 4 },
                new City { ID = 19, Name = "Liverpool", CountryID = 4 },
                new City { ID = 20, Name = "Rome", CountryID = 5 },
                new City { ID = 21, Name = "Milan", CountryID = 5 },
                new City { ID = 22, Name = "Naples", CountryID = 5 },
                new City { ID = 23, Name = "Turin", CountryID = 5 },
                new City { ID = 24, Name = "Florence", CountryID = 5 },
                new City { ID = 25, Name = "Lisbon", CountryID = 6 },
                new City { ID = 26, Name = "Porto", CountryID = 6 },
                new City { ID = 27, Name = "Amsterdam", CountryID = 7 },
                new City { ID = 28, Name = "Rotterdam", CountryID = 7 },
                new City { ID = 29, Name = "Brussels", CountryID = 8 },
                new City { ID = 30, Name = "Antwerp", CountryID = 8 },
                new City { ID = 31, Name = "Moscow", CountryID = 9 },
                new City { ID = 32, Name = "Saint Petersburg", CountryID = 9 },
                new City { ID = 33, Name = "Kazan", CountryID = 9 },
                new City { ID = 34, Name = "Istanbul", CountryID = 10 },
                new City { ID = 35, Name = "Ankara", CountryID = 10 },
                new City { ID = 36, Name = "Izmir", CountryID = 10 },
                new City { ID = 37, Name = "Buenos Aires", CountryID = 11 },
                new City { ID = 38, Name = "Córdoba", CountryID = 11 },
                new City { ID = 39, Name = "São Paulo", CountryID = 12 },
                new City { ID = 40, Name = "Rio de Janeiro", CountryID = 12 },
                new City { ID = 41, Name = "Brasília", CountryID = 12 },
                new City { ID = 42, Name = "Salvador", CountryID = 12 },
                new City { ID = 43, Name = "Fortaleza", CountryID = 12 },
                new City { ID = 44, Name = "Mexico City", CountryID = 13 },
                new City { ID = 45, Name = "Guadalajara", CountryID = 13 },
                new City { ID = 46, Name = "Monterrey", CountryID = 13 },
                new City { ID = 47, Name = "New York", CountryID = 14 },
                new City { ID = 48, Name = "Los Angeles", CountryID = 14 },
                new City { ID = 49, Name = "Chicago", CountryID = 14 },
                new City { ID = 50, Name = "Houston", CountryID = 14 },
                new City { ID = 51, Name = "Miami", CountryID = 14 },
                new City { ID = 52, Name = "Edinburgh", CountryID = 15 },
                new City { ID = 53, Name = "Glasgow", CountryID = 15 },
                new City { ID = 54, Name = "Athens", CountryID = 16 },
                new City { ID = 55, Name = "Thessaloniki", CountryID = 16 },
                new City { ID = 56, Name = "Zurich", CountryID = 17 },
                new City { ID = 57, Name = "Geneva", CountryID = 17 },
                new City { ID = 58, Name = "Vienna", CountryID = 18 },
                new City { ID = 59, Name = "Salzburg", CountryID = 18 },
                new City { ID = 60, Name = "Copenhagen", CountryID = 19 },
                new City { ID = 61, Name = "Oslo", CountryID = 20 },
                new City { ID = 62, Name = "Stockholm", CountryID = 21 },
                new City { ID = 63, Name = "Gothenburg", CountryID = 21 },
                new City { ID = 64, Name = "Warsaw", CountryID = 22 },
                new City { ID = 65, Name = "Krakow", CountryID = 22 },
                new City { ID = 66, Name = "Kyiv", CountryID = 23 },
                new City { ID = 67, Name = "Lviv", CountryID = 23 },
                new City { ID = 68, Name = "Belgrade", CountryID = 24 },
                new City { ID = 69, Name = "Zagreb", CountryID = 25 },
                new City { ID = 70, Name = "Prague", CountryID = 26 },
                new City { ID = 71, Name = "Tokyo", CountryID = 27 },
                new City { ID = 72, Name = "Osaka", CountryID = 27 },
                new City { ID = 73, Name = "Kyoto", CountryID = 27 },
                new City { ID = 74, Name = "Yokohama", CountryID = 27 },
                new City { ID = 75, Name = "Nagoya", CountryID = 27 },
                new City { ID = 76, Name = "Seoul", CountryID = 28 },
                new City { ID = 77, Name = "Busan", CountryID = 28 },
                new City { ID = 78, Name = "Shanghai", CountryID = 29 },
                new City { ID = 79, Name = "Beijing", CountryID = 29 },
                new City { ID = 80, Name = "Guangzhou", CountryID = 29 },
                new City { ID = 81, Name = "Shenzhen", CountryID = 29 },
                new City { ID = 82, Name = "Chengdu", CountryID = 29 },
                new City { ID = 83, Name = "Sydney", CountryID = 30 },
                new City { ID = 84, Name = "Melbourne", CountryID = 30 },
                new City { ID = 85, Name = "Brisbane", CountryID = 30 },
                new City { ID = 86, Name = "Perth", CountryID = 30 },
                new City { ID = 87, Name = "Adelaide", CountryID = 30 },
                new City { ID = 88, Name = "Riyadh", CountryID = 31 },
                new City { ID = 89, Name = "Jeddah", CountryID = 31 },
                new City { ID = 90, Name = "Cairo", CountryID = 32 },
                new City { ID = 91, Name = "Alexandria", CountryID = 32 },
                new City { ID = 92, Name = "Sheffield", CountryID = 4 },
                new City { ID = 93, Name = "Bologna", CountryID = 5 },
                new City { ID = 94, Name = "Philadelphia", CountryID = 14 },
                new City { ID = 95, Name = "Dallas", CountryID = 14 },
                new City { ID = 96, Name = "Novosibirsk", CountryID = 9 },
                new City { ID = 97, Name = "Stuttgart", CountryID = 1 },
                new City { ID = 98, Name = "Bordeaux", CountryID = 3 },
                new City { ID = 99, Name = "Málaga", CountryID = 2 },
                new City { ID = 100, Name = "Curitiba", CountryID = 12 }

            );

        }
    }
}
