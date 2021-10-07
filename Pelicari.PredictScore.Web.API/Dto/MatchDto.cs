using System;

namespace Pelicari.PredictScore.Web.API.Dto
{
    public class MatchDto
    {
        public int RoundId { get; set;}
        public DateTime Date { get; set;}
        public int HomeTeamId { get; set; }
        public int GuestTeamId { get; set; }
        public ScoreDto Score { get; set; }
    }
}
