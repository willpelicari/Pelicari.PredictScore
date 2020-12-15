namespace Pelicari.PredictScore.Data.Models
{
    public class Score  
    {
        public int Id { get; set; }
        public int HomeScore { get; set; }
        public int GuestScore { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public int PredictionId { get; set; }
        public Prediction Prediction { get; set; }
    }
}
