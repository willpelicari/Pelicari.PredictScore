using System.Collections.Generic;

namespace Pelicari.PredictScore.Data.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Prediction> Predictions { get; set; }
    }
}
