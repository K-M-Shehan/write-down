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
      try {
        var response = await _supabase.From<Note>().Get(); // fetches all the rows
        return Ok(response.Models.First());
      }
      catch (Exception ex) {
        return StatusCode(500, ex.Message);
      }
    }

    // creating a note
    [HttpPost]
    public async Task<IActionResult> PostNotes([FromBody] Note newNote) {
      // sending to supabase
      // the id is generated in the database
      newNote.CreatedAt = DateTime.UtcNow;

      var response = await _supabase.From<Note>().Insert(newNote);

      return Ok(response.Models.First());
    }
  }
}
