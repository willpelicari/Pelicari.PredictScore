using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelicari.PredictScore.Data.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        [ForeignKey("userId")]
        public int AdminId { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
