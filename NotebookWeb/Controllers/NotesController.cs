using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotebookData;
using NotebookEntities.NoteBookDB;

namespace NotebookWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NBContext _context;

        public NotesController(NBContext context)
        {
            _context = context;
        }

        // GET: api/Notes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NBNotes>>> GetNBNotes()
        {
            return await _context.NBNotes.ToListAsync();
        }

        // GET: api/Notes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NBNotes>> GetNBNotes(int id)
        {
            var nBNotes = await _context.NBNotes.FindAsync(id);

            if (nBNotes == null)
            {
                return NotFound();
            }

            return nBNotes;
        }

        // PUT: api/Notes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNBNotes(int id, NBNotes nBNotes)
        {
            if (id != nBNotes.IdUser)
            {
                return BadRequest();
            }

            _context.Entry(nBNotes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NBNotesExists(id))
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

        // POST: api/Notes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NBNotes>> PostNBNotes(NBNotes nBNotes)
        {
            _context.NBNotes.Add(nBNotes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNBNotes", new { id = nBNotes.IdUser }, nBNotes);
        }

        // DELETE: api/Notes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NBNotes>> DeleteNBNotes(int id)
        {
            var nBNotes = await _context.NBNotes.FindAsync(id);
            if (nBNotes == null)
            {
                return NotFound();
            }

            _context.NBNotes.Remove(nBNotes);
            await _context.SaveChangesAsync();

            return nBNotes;
        }

        private bool NBNotesExists(int id)
        {
            return _context.NBNotes.Any(e => e.IdUser == id);
        }
    }
}
