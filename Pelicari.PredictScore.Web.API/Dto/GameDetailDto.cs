using System;

namespace Pelicari.PredictScore.Web.API.Dto
{
    public class GameDetailDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TeamDto HomeTeam { get; set; }
        public TeamDto GuestTeam { get; set; }
    }
}
