"use strict";
leesKazen();
async function leesKazen() {
  const response = await fetch("http://localhost:5000/kazen");
  if (response.ok) {
    const kazen = await response.json();
    const ul = document.getElementById("kazen");
    for (const kaas of kazen) {
      const li = document.createElement("li");
      li.innerText = `${kaas.naam}: ${kaas.soort}, ${kaas.smaak}`;
      ul.appendChild(li);
    }
  } else if (response.status === 404) {
    alert("Kaas niet gevonden.");
  } else {
    alert("Technisch probleem, contacteer de helpdesk.");
  }
}
