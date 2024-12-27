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
    public class TranscationModalsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TranscationModalsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/TranscationModals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TranscationModal>>> GetTransaction()
        {
            return await _context.Transaction.ToListAsync();
        }

        [HttpGet("userID")]
        public async Task<ActionResult<IEnumerable<object>>> GetUserTranscation(int userID)
        {
            var UserTanscation = await _context.Transaction
                .Where(t => t.userID == userID)
                .Join(
                    _context.Tickets,
                    transaction => transaction.ticketID,
                    tickets => tickets.ticketID,
                    (transaction, tickets) => new {transaction, tickets })
                .ToListAsync();
            return Ok(UserTanscation);
        }

        // GET: api/TranscationModals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TranscationModal>> GetTranscationModal(int id)
        {
            var transcationModal = await _context.Transaction.FindAsync(id);

            if (transcationModal == null)
            {
                return NotFound();
            }

            return transcationModal;
        }

        // PUT: api/TranscationModals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTranscationModal(int id, TranscationModal transcationModal)
        {
            if (id != transcationModal.transcationID)
            {
                return BadRequest();
            }

            _context.Entry(transcationModal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TranscationModalExists(id))
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

        // POST: api/TranscationModals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TranscationModal>> PostTranscationModal(TranscationModal transcationModal)
        {
            _context.Transaction.Add(transcationModal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTranscationModal", new { id = transcationModal.transcationID }, transcationModal);
        }

        // DELETE: api/TranscationModals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTranscationModal(int id)
        {
            var transcationModal = await _context.Transaction.FindAsync(id);
            if (transcationModal == null)
            {
                return NotFound();
            }

            _context.Transaction.Remove(transcationModal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TranscationModalExists(int id)
        {
            return _context.Transaction.Any(e => e.transcationID == id);
        }
    }
}
