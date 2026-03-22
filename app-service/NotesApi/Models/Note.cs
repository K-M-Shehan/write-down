using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace NotesApi.Models {
  [Table("notes")]
  public class Note : BaseModel {
    [PrimaryKey("id")]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}
