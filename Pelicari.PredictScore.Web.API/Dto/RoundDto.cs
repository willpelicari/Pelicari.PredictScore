using System.Collections.Generic;

namespace Pelicari.PredictScore.Web.API.Dto
{
    public class RoundDto
    {
        public string Description { get; set; }
        public int ScheduleId { get; set; }
        public IEnumerable<int> GamesId { get; set; }
    }
}
