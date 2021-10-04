using Pelicari.PredictScore.Core.Services.Interfaces;
using Pelicari.PredictScore.Data.Models;
using Pelicari.PredictScore.Data.Repositories.Interfaces;

namespace Pelicari.PredictScore.Core.Services
{
    public class SportService : Service<Sport>, IService<Sport>
    {
        public SportService(IRepository<Sport> repository) : base(repository)
        {
        }
    }
}
