'use strict';

document.getElementById('zoeken').onclick = async function () {
  const response = await fetch(
    `http://localhost:5000/kazen/${document.getElementById('id').value}`,
  );

  if (response.ok) {
    const kazen = await response.json();
    document.getElementById('naam').innerText = kazen.naam;
    document.getElementById('soort').innerText = kazen.soort;
    document.getElementById('smaak').innerText = kazen.smaak;
  } else if (response.status === 404) {
    alert('Kaas niet gevonden.');
  } else {
    alert('Technisch probleem, contacteer de helpdesk.');
  }
};
