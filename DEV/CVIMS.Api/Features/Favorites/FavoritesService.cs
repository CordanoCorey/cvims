using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVIMS.Api.Infrastructure.Models;

namespace CVIMS.Api.Features.Favorites
{
    public interface IFavoritesService
    {
        IEnumerable<FavoriteModel> GetFavorites(string userId);
    }

    public class FavoritesService : IFavoritesService
    {
        private readonly IFavoritesRepository _repo;

        public FavoritesService(IFavoritesRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<FavoriteModel> GetFavorites(string userId)
        {
            return _repo.FindByUser(userId);
        }
    }
}
