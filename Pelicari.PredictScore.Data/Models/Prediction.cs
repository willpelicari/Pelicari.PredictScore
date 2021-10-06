using System.ComponentModel.DataAnnotations.Schema;

namespace Pelicari.PredictScore.Data.Models
{
    [Table("Predictions")]
    public class Prediction
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int MatchId {  get; set; }
        public Match Match { get; set; }

        public int ScoreId { get; set; }
        public Score Score { get; set; }
    }
}
