namespace Pelicari.PredictScore.Web.API.Dto
{
    public class ScoreDto
    {
        public int GuestTeamId { get; set; }
        public int GuestScore { get; set; }
        public int HomeScore { get; set; }
        public int HomeTeamId { get; set; }
    }
}
