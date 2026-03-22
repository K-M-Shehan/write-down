export default function NotesList({ notes }) {
  return (
    <div>
      <h2>All Notes</h2>
      <ul>
        { notes.map(note => (
          <li key={note.id}>
            <strong>{note.title}</strong>: {note.content}
          </li>
        ))}
      </ul>
    </div>
  );
}
