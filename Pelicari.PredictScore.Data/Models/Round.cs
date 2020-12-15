using System.Collections.Generic;

namespace Pelicari.PredictScore.Data.Models
{
    public class Round
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        public IEnumerable<Game> Games { get; set; }
    }
}
