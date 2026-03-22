import React, { useState, useEffect } from "react";
import axios from "axios";
import NotesList from "./components/NotesList.jsx";
import NoteForm from "./components/NoteForm.jsx";

const BASE_URL = import.meta.env.VITE_API_URL ?? "http://localhost:5124";

function App() {
  const [notes, setNotes] = useState([]);

  useEffect(() => {
    axios.get(`${BASE_URL}/notes`)
      .then(res => setNotes(res.data))
      .catch(err => console.error(err));
  }, []);

  const handleAddNote = (newNote) => {
    setNotes((prev) => [...prev, newNote]);
  }

  return (
    <div>
      <h1>write down</h1>
      <NoteForm onAdd={handleAddNote} />
      <NotesList notes={notes} />
    </div>
  )
}

export default App;
