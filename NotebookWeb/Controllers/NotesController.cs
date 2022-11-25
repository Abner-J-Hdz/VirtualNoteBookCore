using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotebookData;
using NotebookEntities.NoteBookDB;
using NotebookWeb.Models.Notebook;

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

        ///Obtener todas la notas
        // GET: api/Notes
        [HttpGet]
        public async Task<IEnumerable<NoteViewModel>> getNotes()
        {
            var nbNotes = await _context.NBNotes.ToListAsync();

            return nbNotes.Select(x => new NoteViewModel
            {
                IdNote = x.IdNote,
                Title = x.Title,
                Body = x.Body,
                Created = x.Created,
                Updated = x.Updated
            });
        }

        ///Obtener una notas
        // GET: api/Notes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> getNote([FromRoute] int id)
        {

            var nbNote = await _context.NBNotes.FirstOrDefaultAsync(x => x.IdNote == id);

            if (nbNote == null)
                return NotFound();

            return Ok(new NoteViewModel {
                IdNote = nbNote.IdNote,
                Title = nbNote.Title,
                Body = nbNote.Body,
                Created = nbNote.Created,
                Updated = nbNote.Updated
            });
        }

        //Actulizar una nota
        // PUT: api/Notes
        [HttpPut]
        public async Task<IActionResult> putNotes([FromBody] NoteViewModel note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (note.IdNote < 0)
                return BadRequest();

            var nbNote = await _context.NBNotes.FirstOrDefaultAsync(x => x.IdNote == note.IdNote);

            if (nbNote == null)
                return NotFound();

            nbNote.Title = note.Title;
            nbNote.Body = note.Body;
            nbNote.Updated = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }

        //Crear o guardar una nota
        // POST: api/Notes
        [HttpPost]
        public async Task<IActionResult> postNotes([FromBody] NoteViewModel note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int idNote = _context.NBNotes.OrderByDescending(x => x.IdNote).FirstOrDefault()?.IdNote + 1 ?? 1;

            NBNotes nbNote = new NBNotes {
                IdNote = idNote,
                Title = note.Title,
                Body = note.Body,
                Created = DateTime.Now,
                Updated = DateTime.Now
            };
            try
            {
                _context.NBNotes.Add(nbNote);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE: api/Notes/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<NBNotes>> DeleteNotes([FromRoute] int id)
        //{
        //    try
        //    {
        //        var nBNotes = await _context.NBNotes.FindAsync(id);
        //        if (nBNotes == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.NBNotes.Remove(nBNotes);
        //        await _context.SaveChangesAsync();

        //        return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}

        private bool NBNotesExists(int id)
        {
            return _context.NBNotes.Any(e => e.IdNote == id);
        }
    }
}
