using System;

namespace Pelicari.PredictScore.Web.API.Dto
{
    public class GameDto
    {
        public DateTime Date { get; set; }
        public int HomeTeamId { get; set; }
        public int GuestTeamId { get; set; }
    }
}
