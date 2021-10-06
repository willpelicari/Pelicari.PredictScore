using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelicari.PredictScore.Data.Models
{
    [Table("Groups")]
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AdminId { get; set; }
        public User Admin { get; set; }

        public IList<User> Users { get; set; } = new List<User>();
        public IList<Season> Seasons { get; set; } = new List<Season>();
    }
}
