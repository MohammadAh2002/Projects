using Entities.Models;
using Shared.RequestFeatures.Match;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class RepositoryMatchExtensions
    {
        public static IQueryable<Match> Search(this IQueryable<Match> Teams, MatchParameters Parameters)
        {

            if (!string.IsNullOrWhiteSpace(Parameters.AwayTeam))
            {
                Teams = Teams.Where(m => m.AwayTeam.Name.Contains(Parameters.AwayTeam));
            }

            if (!string.IsNullOrWhiteSpace(Parameters.HomeTeam))
            {
                Teams = Teams.Where(m => m.HomeTeam.Name.Contains(Parameters.HomeTeam));
            }

            if (!string.IsNullOrWhiteSpace(Parameters.Stadium))
            {
                Teams = Teams.Where(m => m.Stadium.Name.Contains(Parameters.Stadium));
            }

            if (!string.IsNullOrWhiteSpace(Parameters.Round))
            {
                Teams = Teams.Where(m => m.Round.Contains(Parameters.Round));
            }

            if (Parameters.KickoffTime != null)
            {
                Teams = Teams.Where(m => m.KickoffTime.Equals(Parameters.KickoffTime));
            }

            if (Parameters.Status != null)
            {
                Teams = Teams.Where(m => m.StatusID.Equals(Parameters.Status));
            }

            return Teams;
        }

        public static IQueryable<Match> Sort(this IQueryable<Match> Matchs, string OrderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(OrderByQueryString))
                return Matchs;

            string[] orderParams = OrderByQueryString.Trim().Split(',');

            PropertyInfo[] propertyInfos = typeof(Team).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            StringBuilder OrderQueryBuilder = new StringBuilder();

            foreach (string param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                string propertyFromQueryName = param.Split(" ")[0];

                PropertyInfo? objectProperty = propertyInfos.FirstOrDefault(pi =>
                    pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase)
                    && Match.AllowedSortProperties.Contains(pi.Name, StringComparer.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                string direction = param.EndsWith(" desc") ? "descending" : "ascending";

                OrderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction}, ");
            }

            string OrderQuery = OrderQueryBuilder.ToString().TrimEnd(',', ' ');

            if (string.IsNullOrWhiteSpace(OrderQuery))
                return Matchs;

            return Matchs.OrderBy(OrderQuery);
        }

    }
}
