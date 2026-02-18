using FetchApi.Data;
using FetchApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FetchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        private readonly AppDbContext _appDb;

        public FavouriteController(AppDbContext appDb) 
            {
                _appDb = appDb;
            }

        [HttpPost]
        public async Task<IActionResult> AddFavourite(Favouritecountry fav)
        {
            _appDb.Favouritecountries.Add(fav);
            await _appDb.SaveChangesAsync();

            return Ok("Saved to favourites");
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserFavourites(int userId)
        {
            var favourites = await _appDb.Favouritecountries
                .Where(f => f.UserId == userId)
                .ToListAsync();

            return Ok(favourites);
        }
    }
}
