using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelicari.PredictScore.Data.Models
{
    [Table("Matches")]
    public class Match
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        public int GuestTeamId { get; set; }
        public Team GuestTeam { get; set; }

        public int ScoreId { get; set; }
        public Score Score { get; set; }

        public int RoundId { get; set; }
        public Round Round { get; set; }
    }
}
