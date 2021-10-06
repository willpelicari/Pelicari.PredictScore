using System.Collections.Generic;

namespace Pelicari.PredictScore.Web.API.Dto
{
    public class RoundDto
    {
        public string Description { get; set; }
        public int SeasonId { get; set; }
        public IEnumerable<MatchDto> Matches { get; set; }
    }
}
