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
    public class TicketModalsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TicketModalsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/TicketModals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketModal>>> GetTickets()
        {
            return await _context.Tickets.ToListAsync();
        }

        //get by tickets by userID
        [HttpGet("userID")]
        public async Task<ActionResult<IEnumerable<object>>> GetTicketsOnUserID(int userID)
        {
            var userTickets  = await _context.Tickets
                .Where(t => t.userID == userID)
                .Join(_context.Movies,
                    ticket => ticket.movieID ,
                    movie => movie.MovieID,
                    (ticket, movie) => new {ticket,movie})
                .Join(_context.Shows,
                    ticketmovie => ticketmovie.ticket.showID,
                    show => show.showID,
                    (ticketmovie, show) => new
                    {
                        ticketID = ticketmovie.ticket.ticketID,
                        movieID = ticketmovie.movie.MovieID,
                        title = ticketmovie.movie.Title,
                        poster = ticketmovie.movie.PosterURL,
                        description = ticketmovie.movie.Description,
                        showDate = show.Date,
                        showSlot = show.slot,
                        count = ticketmovie.ticket.count,
                        seats = ticketmovie.ticket.seats,
                        cost = show.cost
                    })
                
                .ToListAsync();
            return userTickets;
        }

        // GET: api/TicketModals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketModal>> GetTicketModal(int id)
        {
            var ticketModal = await _context.Tickets.FindAsync(id);

            if (ticketModal == null)
            {
                return NotFound();
            }

            return ticketModal;
        }

        // PUT: api/TicketModals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketModal(int id, TicketModal ticketModal)
        {
            if (id != ticketModal.ticketID)
            {
                return BadRequest();
            }

            _context.Entry(ticketModal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketModalExists(id))
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

        // POST: api/TicketModals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TicketModal>> PostTicketModal(TicketModal ticketModal)
        {
            _context.Tickets.Add(ticketModal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketModal", new { id = ticketModal.ticketID }, ticketModal);
        }

        // DELETE: api/TicketModals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketModal(int id)
        {
            var ticketModal = await _context.Tickets.FindAsync(id);
            if (ticketModal == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(ticketModal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketModalExists(int id)
        {
            return _context.Tickets.Any(e => e.ticketID == id);
        }
    }
}
