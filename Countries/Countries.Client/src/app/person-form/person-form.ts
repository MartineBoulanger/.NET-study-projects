import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Person } from '@app/model/person';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-person-form',
  imports: [FormsModule, CommonModule],
  templateUrl: './person-form.html',
  styleUrl: './person-form.css',
})
export class PersonForm {
  protected cars = ['Volkswagen', 'Peugeot', 'Audi'];
  protected person = new Person(55, 'Smits', this.cars[0], 'Jean');
  protected submitted = false;
  // als het formulier gesubmit wordt zal deze functie worden uitgevoerd
  protected onSubmit() {
    this.submitted = true;
  }
  // gaan we gebruiken om de inhoud van het form weer te geven
  protected get formValues() {
    return JSON.stringify(this.person);
  }
  protected newPerson() {
    this.person = new Person(102, '', '');
  }
}
