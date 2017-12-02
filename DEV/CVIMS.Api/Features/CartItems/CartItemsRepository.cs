using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CVIMS.Api.Infrastructure.Repositories;
using CVIMS.Entity.Context;
using CVIMS.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVIMS.Api.Features.CartItems
{
    public interface ICartItemsRepository : IBaseRepository<CartItem, CartItemModel>
    {
        IEnumerable<CartItemModel> FindByUser(string userId);
        void Delete(string userId, int productId);
    }
    public class CartItemsRepository : BaseRepository<CartItem, CartItemModel>, ICartItemsRepository
    {
        public CartItemsRepository(CVIMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IEnumerable<CartItemModel> FindByUser(string userId)
        {
            return FindBy(x => x.UserId == userId);
        }

        public void Delete(string userId, int productId)
        {
            var entity = FindEntityByKey(userId, productId);
            _dbSet.Remove(entity);
            Save();
        }

        protected CartItem FindEntityByKey(string userId, int productId)
        {
            return DbSetSingle.SingleOrDefault(x => x.UserId == userId && x.ProductId == productId);
        }

        protected override IQueryable<CartItem> Include(IQueryable<CartItem> queryable)
        {
            return queryable.Include(x => x.Product);
        }

        protected override IQueryable<CartItem> IncludeSingle(IQueryable<CartItem> queryable)
        {
            return Include(queryable);
        }
    }
}
