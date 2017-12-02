using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CVIMS.Api.Infrastructure.Repositories;
using CVIMS.Entity.Context;
using CVIMS.Entity.Entities;

namespace CVIMS.Api.Features.Favorites
{
    public interface IFavoritesRepository : IBaseRepository<Favorite, FavoriteModel>
    {
        IEnumerable<FavoriteModel> FindByUser(string userId);
    }
    public class FavoritesRepository : BaseRepository<Favorite, FavoriteModel>, IFavoritesRepository
    {
        public FavoritesRepository(CVIMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IEnumerable<FavoriteModel> FindByUser(string userId)
        {
            return FindBy(x => x.UserId == userId);
        }
    }
}
