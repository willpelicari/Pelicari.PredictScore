using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelicari.PredictScore.Data.Models
{
    [Table("Rounds")]
    public class Round
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public int ScheduleId { get; set; }

        public Schedule Schedule { get; set; }

        public IEnumerable<Game> Games { get; set; } = new List<Game>();
    }
}
