using System.Collections.Generic;

namespace Pelicari.PredictScore.Data.Models
{
    public class Sport
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Schedule> Schedules { get; set; }
    }
}
