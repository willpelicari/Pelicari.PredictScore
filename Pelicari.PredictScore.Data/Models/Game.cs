using System;

namespace Pelicari.PredictScore.Data.Models
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Team HomeTeam { get; set; }
        public Team GuestTeam { get; set; }

        public int RoundId { get; set; }
        public Round Round { get; set; }
    }
}
