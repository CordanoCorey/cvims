using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using CVIMS.Api.Infrastructure.Auth;
using CVIMS.Api.Repositories;
using CVIMS.Api.Infrastructure.Lookup;
using CVIMS.Api.Infrastructure.Services;
using CVIMS.Api.Features.CartItems;
using CVIMS.Api.Features.Categories;
using CVIMS.Api.Features.Favorites;
using CVIMS.Api.Features.Orders;
using CVIMS.Api.Features.Products;

namespace CVIMS.Api
{
    public partial class Startup
    {
        public static void ConfigureDIServices(IServiceCollection services)
        {
            //Auth
            services.AddScoped<IClaimsService, ClaimsService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthorizationHandler, AccountRequirementHandler>();

            //Lookup
            services.AddScoped<ILookupRepository, LookupRepository>();

            //Search
            services.AddScoped<ISearchService, SearchService>();

            //CartItems
            services.AddScoped<ICartItemsService, CartItemsService>();
            services.AddScoped<ICartItemsRepository, CartItemsRepository>();

            //Categories
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();

            //Favorites
            services.AddScoped<IFavoritesService, FavoritesService>();
            services.AddScoped<IFavoritesRepository, FavoritesRepository>();

            //Orders
            services.AddScoped<IOrdersService, OrderStatusService>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();

            //Products
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IProductsRepository, ProductsRepository>();

        }
    }
}