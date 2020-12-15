using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelicari.PredictScore.Data.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int SportId { get; set; }
        public Sport Sport { get; set; }

        public IEnumerable<Round> Rounds { get; set; }
        public IEnumerable<Group> Groups { get; set; }
    }
}
