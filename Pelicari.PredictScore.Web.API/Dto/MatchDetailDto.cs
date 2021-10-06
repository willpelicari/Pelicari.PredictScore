using System;

namespace Pelicari.PredictScore.Web.API.Dto
{
    public class MatchDetailDto
    {
        public int Id { get; set; }
        public TeamDto HomeTeam { get; set; }
        public TeamDto GuestTeam { get; set; }
    }
}
