import { useEffect, useState } from "react";
import { getNotes, createNote } from "./api";

export default function App() {
  const [notes, setNotes] = useState([]);
  const [title, setTitle] = useState("");
  const [content, setContent] = useState("");

  useEffect(() => {
    getNotes().then(setNotes);
  }, []);

  async function handleSubmit(e) {
    e.preventDefault();
    const newNote = await createNote(title, content);
    setNotes([...notes, newNote]);
    setTitle("");
    setContent("");
  }

  return (
    <div>
      <h1>Notes</h1>

      <form onSubmit={handleSubmit}>
        <input
          placeholder="Title"
          value={title}
          onChange={e => setTitle(e.target.value)}
        />
        <textarea
          placeholder="Content"
          value={content}
          onChange={e => setContent(e.target.value)}
        />
        <button type="submit">Add Note</button>
      </form>

      {notes.map(note => (
        <div key={note.id}>
          <h3>{note.title}</h3>
          <p>{note.content}</p>
        </div>
      ))}
    </div>
  );
}
