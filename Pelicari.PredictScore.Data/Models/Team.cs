using System.ComponentModel.DataAnnotations.Schema;

namespace Pelicari.PredictScore.Data.Models
{
    [Table("Teams")]
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public string Logo { get; set; }

        public int SportId { get; set; }
        public Sport Sport { get; set; }
    }
}
