using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CVIMS.Api.Infrastructure.Controllers;
using CVIMS.Api.Infrastructure.Models;

namespace CVIMS.Api.Features.Favorites
{
    [Route("api/favorites")]
    public class FavoritesController : BaseController
    {
        private readonly IFavoritesService _service;

        public FavoritesController(IFavoritesService service)
        {
            _service = service;
        }

        /**
         *  GET: api/favorites
         */
        [HttpGet]
        public IActionResult GetFavorites()
        {
            return Get(_service.GetFavorites, UserId);
        }
    }
}
