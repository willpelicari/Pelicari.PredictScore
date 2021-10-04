using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelicari.PredictScore.Data.Models
{
    [Table("Games")]
    public class Game
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public Round Round { get; set; }
        public Team HomeTeam { get; set; }
        public Team GuestTeam { get; set; }       
    }
}
