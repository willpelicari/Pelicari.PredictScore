using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelicari.PredictScore.Data.Models
{
    [Table("Schedules")]
    public class Schedule
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int SportId { get; set; }
        public Sport Sport { get; set; }

        public IList<Round> Rounds { get; set; } = new List<Round>();
        public IList<Group> Groups { get; set; } = new List<Group>();
    }
}
