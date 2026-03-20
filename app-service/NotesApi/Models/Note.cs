using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace NotesApi.Models {
  [Table("notes")]
  public class Note : BaseModel {
    [PrimaryKey("id")]
    public Guid Id { get; set; }

    [Column("title")]
    public string Title { get; set; } = string.Empty;

    [Column("content")]
    public string Content { get; set; } = string.Empty;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
  }
}
