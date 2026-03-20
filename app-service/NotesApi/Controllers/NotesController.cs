using Microsoft.AspNetCore.Mvc;
using NotesApi.Models;
using Supabase;
using System;

namespace NotesApi.Controllers {
  [ApiController]
  [Route("[controller]")]
  public class NotesController : ControllerBase {
    
    private readonly Supabase.Client _supabase;

    public NotesController() {
      string supabaseUrl = Environment.GetEnvironmentVariable("SUPABASE_URL");
      string supabaseKey = Environment.GetEnvironmentVariable("SUPABASE_ANON_KEY");

      if (string.IsNullOrEmpty(supabaseUrl) || string.IsNullOrEmpty(supabaseKey)) {
        throw new Exception("Supabase credentials are not set in environment variables!");
      }

      _supabase = new Supabase.Client(supabaseUrl, supabaseKey);
      _supabase.InitializeAsync().Wait();
    }

    // getting all the notes
    [HttpGet]
    public async Task<IActionResult> GetNotes() {
      // fetching notes from supabase
      var response = await _supabase.From<Note>().Get(); // fetches all the rows

      return Ok(response.Models);
    }

    // creating a note
    [HttpPost]
    public async Task<IActionResult> PostNotes([FromBody] Note newNote) {
      // sending to supabase
      newNote.Id = Guid.NewGuid();
      newNote.CreatedAt = DateTime.UtcNow;

      var response = await _supabase.From<Note>().Insert(newNote);

      return CreatedAtAction(nameof(GetNotes), new { id = newNote.Id }, response.Models.First());
    }
  }
}
