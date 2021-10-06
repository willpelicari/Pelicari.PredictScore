using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelicari.PredictScore.Data.Models
{
    [Table("Sports")]
    public class Sport
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Season> Seasons { get; set; } = new List<Season>();
    }
}
