using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelicari.PredictScore.Data.Models
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public IList<Group> Groups { get; set; } = new List<Group>();
        public IList<Prediction> Predictions { get; set; } = new List<Prediction>();
    }
}
