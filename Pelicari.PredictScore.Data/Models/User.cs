using System.Collections.Generic;

namespace Pelicari.PredictScore.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<Prediction> Predictions { get; set; }
    }
}
