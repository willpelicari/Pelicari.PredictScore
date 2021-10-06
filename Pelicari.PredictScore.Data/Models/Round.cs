using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelicari.PredictScore.Data.Models
{
    [Table("Rounds")]
    public class Round
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int SeasonId { get; set; }
        public Season Season { get; set; }

        public IEnumerable<Match> Matches { get; set; } = new List<Match>();
    }
}
