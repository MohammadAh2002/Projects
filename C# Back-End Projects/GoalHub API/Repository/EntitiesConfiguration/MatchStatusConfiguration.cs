using Entities.Enums;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.EntitiesConfiguration
{
    public class MatchStatusConfiguration : IEntityTypeConfiguration<MatchStatus>
    {
        public void Configure(EntityTypeBuilder<MatchStatus> builder)
        {

            builder.HasIndex(MatchStatus => MatchStatus.Name).IsUnique();

            builder.HasIndex(MatchStatus => MatchStatus.Description).IsUnique();

            builder.HasData(
                   new MatchStatus
                   {
                       ID = (short)EnumMatchStatuses.Scheduled,
                       Name = "Scheduled",
                       Description = "The match is planned and scheduled to take place in the future."
                   },
                   new MatchStatus
                   {
                       ID = (short)EnumMatchStatuses.Live,
                       Name = "Live",
                       Description = "The match is currently in progress."
                   },
                   new MatchStatus
                   {
                       ID = (short)EnumMatchStatuses.Finished,
                       Name = "Finished",
                       Description = "The match has ended and the final result is recorded."
                   },
                   new MatchStatus
                   {
                       ID = (short)EnumMatchStatuses.Canceled,
                       Name = "Canceled",
                       Description = "The match was canceled and will not take place."
                   },
                   new MatchStatus
                   {
                       ID = (short)EnumMatchStatuses.Postponed,
                       Name = "Postponed",
                       Description = "The match has been temporarily stopped and will continue later; the time already played will still count."
                   }
            );

        }
    }
}
