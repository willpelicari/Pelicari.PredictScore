using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelicari.PredictScore.Data.Models
{
    [Table("Games")]
    public class Game
    {
        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        public int GuestTeamId { get; set; }
        public Team GuestTeam { get; set; }
        
        public IEnumerable<Round> Rounds { get; set; }
    }
}
