using System.Collections.Generic;

namespace Pelicari.PredictScore.Web.API.Dto
{
    public class PredictionDto
    {
        public IEnumerable<ScoreDto> Scores { get; set; }
    }
}
