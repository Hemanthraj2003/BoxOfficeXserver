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
    public class TheaterModelsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TheaterModelsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/TheaterModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TheaterModel>>> GetTheater()
        {
            return await _context.Theater.ToListAsync();
        }

        // GET: api/TheaterModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TheaterModel>> GetTheaterModel(int id)
        {
            var theaterModel = await _context.Theater.FindAsync(id);

            if (theaterModel == null)
            {
                return NotFound();
            }

            return theaterModel;
        }

        // PUT: api/TheaterModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTheaterModel(int id, TheaterModel theaterModel)
        {
            if (id != theaterModel.theaterId)
            {
                return BadRequest();
            }

            _context.Entry(theaterModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TheaterModelExists(id))
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

        // POST: api/TheaterModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TheaterModel>> PostTheaterModel(TheaterModel theaterModel)
        {
            _context.Theater.Add(theaterModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTheaterModel", new { id = theaterModel.theaterId }, theaterModel);
        }

        // DELETE: api/TheaterModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheaterModel(int id)
        {
            var theaterModel = await _context.Theater.FindAsync(id);
            if (theaterModel == null)
            {
                return NotFound();
            }

            _context.Theater.Remove(theaterModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TheaterModelExists(int id)
        {
            return _context.Theater.Any(e => e.theaterId == id);
        }
    }
}
