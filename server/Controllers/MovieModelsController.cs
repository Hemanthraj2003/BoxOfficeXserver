using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.DBContext;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieModelsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public MovieModelsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/MovieModels gets all the data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieModel>>> GetMovies()
        {
            var latest5Movies = await _context.Movies
                .OrderByDescending(m => m.ReleaseDate).Take(6).ToListAsync();
            return Ok(latest5Movies);
        }

        [HttpGet("id")]
        public async Task<ActionResult<MovieModel>> GetMoviesById(int id)
        {
            var result = await _context.Movies.FindAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            return result;
        }



            //GET: api/MovieModels/{any}
            [HttpGet("{keyword}")]
        public async Task<ActionResult<IEnumerable<MovieModel>>> GetMoviesByKeyWord(string keyword)
        {
            if (keyword == null)
            {
                return BadRequest("null");
            }

            var searchResult = await _context.Movies
                .Where(m => EF.Functions.Like(m.Title, $"{keyword}%"))
                .ToListAsync();
            return Ok(searchResult);
        }
        // PUT: api/MovieModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieModel(int id, MovieModel movieModel)
        {
            if (id != movieModel.MovieID)
            {
                return BadRequest();
            }

            _context.Entry(movieModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MovieModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieModel>> PostMovieModel(MovieModel movieModel)
        {
            _context.Movies.Add(movieModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovies", new { id = movieModel.MovieID }, movieModel);
        }

        // DELETE: api/MovieModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieModel(int id)
        {
            var movieModel = await _context.Movies.FindAsync(id);
            if (movieModel == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movieModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieModelExists(int id)
        {
            return _context.Movies.Any(e => e.MovieID == id);
        }
    }
}
