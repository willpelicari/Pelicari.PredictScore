using System.Collections.Generic;

namespace Pelicari.PredictScore.Web.API.Dto
{
    public class GroupDto
    {
        public string Name { get; set; }
        public int AdminId { get; set; }
        public IEnumerable<int> SeasonsId { get; set; }
        public IEnumerable<int> PlayersId { get; set; }
    }
}
