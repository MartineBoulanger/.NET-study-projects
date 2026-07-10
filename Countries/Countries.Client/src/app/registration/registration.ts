import { Component } from '@angular/core';
import { JsonPipe, CommonModule } from '@angular/common';
import {
  ReactiveFormsModule,
  FormControl,
  FormGroup,
  FormArray,
  FormBuilder,
} from '@angular/forms';

@Component({
  selector: 'app-registration',
  imports: [ReactiveFormsModule, JsonPipe, CommonModule],
  templateUrl: './registration.html',
  styleUrl: './registration.css',
})
export class Registration {
  // protected registrationModel = new FormGroup({
  //   firstName: new FormControl(''),
  //   lastName: new FormControl(''),
  //   address: new FormGroup({
  //     street: new FormControl(''),
  //     zipcode: new FormControl(''),
  //     city: new FormControl(''),
  //   }),
  //   phoneNumbers: new FormArray([new FormControl('')]),
  // });
  protected registrationModel!: FormGroup;
  constructor(private fb: FormBuilder) {
    this.registrationModel = this.fb.group({
      firstName: [''],
      lastName: [''],
      address: this.fb.group({
        street: [''],
        zipcode: [''],
        city: [''],
      }),
      phoneNumbers: this.fb.array([this.fb.control('')]),
    });
  }
  // getter om gemakkelijker aan de controls te kunnen van de FormArray
  protected get phoneNumbers() {
    return this.registrationModel.get('phoneNumbers') as FormArray;
  }
  // this.phoneNumbers verwijst naar de getter functie
  protected addPhoneNumber() {
    // this.phoneNumbers.push(new FormControl(''));
    this.phoneNumbers.push(this.fb.control(''));
  }
  protected removePhoneNumberAt(index: number) {
    this.phoneNumbers.removeAt(index);
  }
  protected registerOnSubmit() {
    console.log(this.registrationModel.value);
  }
  protected toAntwerp() {
    this.registrationModel.get('address')!.get('city')!.setValue('Antwerpen');
  }
  protected johnnyLivesInAntwerp() {
    this.registrationModel.patchValue({
      firstName: 'Johnny',
      address: {
        city: 'Antwerpen',
      },
    });
  }
}
