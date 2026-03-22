import React, { useState } from "react";
import axios from "axios";

const BASE_URL = import.meta.env.VITE_API_URL ?? "http://localhost:5124";

export default function NoteForm({ onAdd }) {
  const [title, setTitle] = useState("");
  const [content, setContent] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const res = await axios.post(`${BASE_URL}/notes`, { title, content });
      onAdd(res.data);
      setTitle("");
      setContent("");
    } catch (err) {
      console.error(err);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <input value={title} onChange={e => setTitle(e.target.value)} placeholder="Title"/>
      <input value={content} onChange={e => setContent(e.target.value)} placeholder="Content"/>
      <button type="submit">Add Note</button>
    </form>
  );
}
