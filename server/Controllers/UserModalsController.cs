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
    public class UserModalsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public UserModalsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/UserModals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModal>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/UserModals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModal>> GetUserModal(int id)
        {
            var userModal = await _context.Users.FindAsync(id);

            if (userModal == null)
            {
                return NotFound();
            }

            return userModal;
        }

        // PUT: api/UserModals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserModal(int id, UserModal userModal)
        {
            if (id != userModal.userID)
            {
                return BadRequest();
            }

            _context.Entry(userModal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModalExists(id))
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

        // POST: api/UserModals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserModal>> PostUserModal(UserModal userModal)
        {
            _context.Users.Add(userModal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserModal", new { id = userModal.userID }, userModal);
        }

        // DELETE: api/UserModals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserModal(int id)
        {
            var userModal = await _context.Users.FindAsync(id);
            if (userModal == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userModal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserModalExists(int id)
        {
            return _context.Users.Any(e => e.userID == id);
        }
    }
}
