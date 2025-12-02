using Entities.Models;
using Shared.RequestFeatures.Player;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Repository.Extensions
{
    public static class RepositoryPlayerExtensions
    {
        public static IQueryable<Player> Search(this IQueryable<Player> Player, PlayerParameters Parameters)
        {

            if (!string.IsNullOrWhiteSpace(Parameters.Position))
            {

                Player = Player.Where(t => t.Position.Contains(Parameters.Position));
            }

            if (!string.IsNullOrWhiteSpace(Parameters.CurrentTeam))
            {
                Player = Player.Where(t => t.CurrentTeam.Name.Contains(Parameters.CurrentTeam));
            }

            if (Parameters.Gender.HasValue)
            {
                Player = Player.Where(p => p.Person.Gender == Parameters.Gender.Value);
            }

            return Player;
        }

    }
}
