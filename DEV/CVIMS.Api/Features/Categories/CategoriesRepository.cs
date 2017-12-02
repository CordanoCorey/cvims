using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CVIMS.Api.Infrastructure.Repositories;
using CVIMS.Entity.Context;
using CVIMS.Entity.Entities;

namespace CVIMS.Api.Features.Categories
{
    public interface ICategoriesRepository : IBaseRepository<Category, CategoryModel>
    {
        IEnumerable<CategoryModel> AllSchoolStoreCategories();
        IEnumerable<CategoryModel> AllStaffStoreCategories();
    }
    public class CategoriesRepository : BaseRepository<Category, CategoryModel>, ICategoriesRepository
    {
        public CategoriesRepository(CVIMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IEnumerable<CategoryModel> AllSchoolStoreCategories()
        {
            return FindBy(x => x.LocationId == 2);
        }

        public IEnumerable<CategoryModel> AllStaffStoreCategories()
        {
            return FindBy(x => x.LocationId == 1);
        }
    }
}
