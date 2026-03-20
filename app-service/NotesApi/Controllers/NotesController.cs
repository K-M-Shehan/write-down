using Microsoft.AspNetCore.Mvc;

namespace NotesApi.Controllers {
  [ApiController]
  [Route("[controller]")]
  public class NotesController : ControllerBase {
    // getting all the notes
    [HttpGet]
    public IActionResult GetNotes() {
      // fetching notes from supabase
      return Ok("this will return all the notes");
    }
  }
}
