using Microsoft.AspNetCore.Mvc;
using NotesApi.Models;
using Supabase;
using System;

namespace NotesApi.Controllers {
  [ApiController]
  [Route("[controller]")]
  public class NotesController : ControllerBase {
    
    private readonly Supabase.Client _supabase;

    public NotesController(Supabase.Client supabase) {
      _supabase = supabase;
    }

    // getting all the notes
    [HttpGet]
    public async Task<IActionResult> GetNotes() {
      // fetching notes from supabase
      var response = await _supabase.From<Note>().Get(); // fetches all the rows

      var notesDto = response.Models.Select(note => new NoteDto {
        Id = note.Id,
        Title = note.Title,
        Content = note.Content,
        CreatedAt = note.CreatedAt
      }).ToList();

      return Ok(notesDto);
    }

    // creating a note
    [HttpPost]
    public async Task<IActionResult> PostNotes([FromBody] Note newNote) {
      // sending to supabase
      // the id is generated in the database
      newNote.CreatedAt = DateTime.UtcNow;

      try {
        var response = await _supabase.From<Note>().Insert(newNote);
        
        if(response.Models.Count == 0)
          return StatusCode(500, "Insert failed");

        var note = response.Models.First();

        var dto = new NoteDto { // mapping to dto
          Id = note.Id,
          Title = note.Title,
          Content = note.Content,
          CreatedAt = note.CreatedAt
        };

        return Ok(dto);

      }
      catch(Exception ex) {
        return StatusCode(500, ex.Message);
      }
    }
  }
}
