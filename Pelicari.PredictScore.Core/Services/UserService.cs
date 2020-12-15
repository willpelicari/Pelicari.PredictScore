using Pelicari.PredictScore.Core.Services.Interfaces;
using Pelicari.PredictScore.Data.Models;
using Pelicari.PredictScore.Data.Repositories.Interfaces;

namespace Pelicari.PredictScore.Core.Services
{
    public class UserService : Service<User>, IService<User>
    {
        public UserService(IRepository<User> repository) : base(repository)
        {
        }
    }
}
