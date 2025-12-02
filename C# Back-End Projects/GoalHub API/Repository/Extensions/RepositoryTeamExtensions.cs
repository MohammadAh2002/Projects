using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class RepositoryTeamExtensions
    {

        public static IQueryable<Team> Search(this IQueryable<Team> Team, TeamParameters Parameters)
        {

            if (!string.IsNullOrWhiteSpace(Parameters.Abbreviation))
            {

                Team = Team.Where(t => t.Abbreviation.Contains(Parameters.Abbreviation));
            }
            
            if (!string.IsNullOrWhiteSpace(Parameters.Stadium))
            {

                Team = Team.Where(t => t.Stadium.Name.Contains(Parameters.Stadium));
            }

            if (Parameters.AfterFoundedDate.HasValue)
            {
                Team = Team.Where(t => t.FoundedDate >= Parameters.AfterFoundedDate.Value);
            }

            if (Parameters.BeforeFoundedDate.HasValue)
            {
                Team = Team.Where(t => t.FoundedDate <= Parameters.BeforeFoundedDate.Value);
            }

            return Team;
        }

        public static IQueryable<Team> Sort(this IQueryable<Team> Teams, string OrderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(OrderByQueryString))
                return Teams;

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
                    && Team.AllowedSortProperties.Contains(pi.Name, StringComparer.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                string direction = param.EndsWith(" desc") ? "descending" : "ascending";

                OrderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction}, "); 
            }

            string OrderQuery = OrderQueryBuilder.ToString().TrimEnd(',', ' ');

            if (string.IsNullOrWhiteSpace(OrderQuery))
                return Teams;

            return Teams.OrderBy(OrderQuery);
        }

    }
}
