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
    public class ShowModelsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ShowModelsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/ShowModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShowModel>>> GetShows()
        {
            return await _context.Shows.ToListAsync();
        }

        // GET: api/ShowModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShowModel>> GetShowModel(int id)
        {
            var showModel = await _context.Shows.FindAsync(id);

            if (showModel == null)
            {
                return NotFound();
            }

            return showModel;
        }

        // GET: api/showModels/movieId/{id}
        [HttpGet("movieId")]
        public async Task<ActionResult<object>> GetShowsForMovie(int movieId)
        {
            var showsForMovie = await _context.Shows
                .Where( show => show.movieID == movieId )
                
                .ToListAsync();
            return showsForMovie;

        }

        // PUT: api/ShowModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShowModel(int id, ShowModel showModel)
        {
            if (id != showModel.showID)
            {
                return BadRequest();
            }

            _context.Entry(showModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowModelExists(id))
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

        // POST: api/ShowModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShowModel>> PostShowModel(ShowModel showModel)
        {
            _context.Shows.Add(showModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShowModel", new { id = showModel.showID }, showModel);
        }

        // DELETE: api/ShowModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShowModel(int id)
        {
            var showModel = await _context.Shows.FindAsync(id);
            if (showModel == null)
            {
                return NotFound();
            }

            _context.Shows.Remove(showModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShowModelExists(int id)
        {
            return _context.Shows.Any(e => e.showID == id);
        }
    }
}
