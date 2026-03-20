const BASE_URL = import.meta.env.VITE_API_URL ?? "http://localhost:5124";

export async function getNotes() {
  const res = await fetch(`${BASE_URL}/notes`);
  return res.json();
}

export async function createNote(title, content) {
  const res = await fetch(`${BASE_URL}/notes`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ title, content }),
  });
  return res.json();
}
