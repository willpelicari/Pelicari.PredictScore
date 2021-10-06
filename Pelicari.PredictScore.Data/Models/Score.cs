using System.ComponentModel.DataAnnotations.Schema;

namespace Pelicari.PredictScore.Data.Models
{
    [Table("Scores")]
    public class Score  
    {
        public int Id { get; set; }
        public int HomeScore { get; set; }
        public int GuestScore { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }
    }
}
