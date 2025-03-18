using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using FullStackApp_Server.Models;
namespace FullStackApp_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventContext _context;

        public EventController(EventContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventModel>>> GetEvents()
        {
            if (_context.Events == null)
            {
                return NotFound();
            }
            return await _context.Events.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventModel>> GetEvent(int id)
        {
            var eventModel = await _context.Events.FindAsync(id);

            if (eventModel == null)
            {
                return NotFound();
            }

            return eventModel;
        }

        [HttpPost]
        public async Task<ActionResult<EventModel>> PostEvent(EventModel eventModel)
        {
            _context.Events.Add(eventModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = eventModel.Id }, eventModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, EventModel eventModel)
        {
            if (id != eventModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var eventModel = await _context.Events.FindAsync(id);
            if (eventModel == null)
            {
                return NotFound();
            }

            _context.Events.Remove(eventModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventExists(int id)
        {
            return (_context.Events?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}