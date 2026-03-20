using Microsoft.AspNetCore.Mvc;
using NotesApi.Models;

namespace NotesApi.Controllers {
  [ApiController]
  [Route("[controller]")]
  public class NotesController : ControllerBase {
    // a list of notes for now
    List<Note> _notes = new List<Note>() {
      new Note { Id = 1, Title = "One Piece Final chapter", Content = "It's the friends you made along the way :)" },
      new Note { Id = 2, Title = "Groceries", Content = "2 Eggs, 1 cola, 2 pkts instant noodles" }
    };

    // getting all the notes
    [HttpGet]
    public IActionResult GetNotes() {
      // fetching notes from supabase
      return Ok(_notes);
    }
  }
}
