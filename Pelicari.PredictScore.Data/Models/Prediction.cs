using System.Collections.Generic;

namespace Pelicari.PredictScore.Data.Models
{
    public class Prediction
    {
        public int Id { get; set; }

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<Score> Scores { get; set; }
    }
}
