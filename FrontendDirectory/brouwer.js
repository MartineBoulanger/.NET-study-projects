'use strict';

document.getElementById('zoeken').onclick = async function () {
  const response = await fetch(
    `http://localhost:5000/brouwers/${document.getElementById('id').value}`,
  );

  if (response.ok) {
    const brouwer = await response.json();
    document.getElementById('naam').innerText = brouwer.naam;
    document.getElementById('postcode').innerText = brouwer.postcode;
  } else if (response.status === 404) {
    alert('Brouwer niet gevonden.');
  } else {
    alert('Technisch probleem, contacteer de helpdesk.');
  }
};
