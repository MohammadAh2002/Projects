using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntitiesConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                },
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Name = "Data Analyst",
                    NormalizedName = "DATA ANALYST"
                },
                new IdentityRole
                {
                    Name = "Team Manager",
                    NormalizedName = "TEAM MANAGER"
                },
                new IdentityRole
                {
                    Name = "Player Manager",
                    NormalizedName = "PLAYER MANAGER"
                },
                new IdentityRole
                {
                    Name = "Match Manager",
                    NormalizedName = "MATCH MANAGER"
                },
                new IdentityRole
                {
                    Name = "Match Viewer",
                    NormalizedName = "MATCH VIEWER"
                }
            );
        }
    }
}
