using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVIMS.Api.Infrastructure.Models;

namespace CVIMS.Api.Features.Categories
{
    public interface ICategoriesService
    {
        IEnumerable<CategoryModel> GetCategories();
        IEnumerable<CategoryModel> GetSchoolStoreCategories();
        IEnumerable<CategoryModel> GetStaffStoreCategories();
    }

    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _repo;

        public CategoriesService(ICategoriesRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            return _repo.All();
        }

        public IEnumerable<CategoryModel> GetSchoolStoreCategories()
        {
            return _repo.AllSchoolStoreCategories();
        }

        public IEnumerable<CategoryModel> GetStaffStoreCategories()
        {
            return _repo.AllStaffStoreCategories();
        }
    }
}
